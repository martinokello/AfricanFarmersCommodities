using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinForms.LocationService.Messages;
using XamarinForms.LocationService.Utils;

namespace XamarinForms.LocationService.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region vars
        private double latitude;
        private double longitude;
        public string userMessage;
        public bool startEnabled;
        public bool stopEnabled;
        #endregion vars

        #region properties
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }
        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }
        public string UserMessage
        {
            get => userMessage;
            set => SetProperty(ref userMessage, value);
        }
        public bool StartEnabled
        {
            get => startEnabled;
            set => SetProperty(ref startEnabled, value);
        }
        public bool StopEnabled
        {
            get => stopEnabled;
            set => SetProperty(ref stopEnabled, value);
        }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string VehicleRegistration { get; set; }
        public bool UpdatePhoneNumber { get; set; }
        public string CompanyLogo { get; set; }
        #endregion properties

        #region commands
        public Command StartCommand { get; }
        public Command EndCommand { get; }
        #endregion commands

        readonly ILocationConsent locationConsent;

        public MainPageViewModel()
        {
            locationConsent = DependencyService.Get<ILocationConsent>();
            StartCommand = new Command(() => OnStartClick());
            EndCommand = new Command(() => OnStopClick());
            HandleReceivedMessages();
            locationConsent.GetLocationConsent();
            StartEnabled = true;
            StopEnabled = false;
            ValidateStatus();
            //CompanyLogo = "martin.jpg";
        }

        public void OnStartClick()
        {
            Start();
        }

        public void OnStopClick()
        {
            var message = new StopServiceMessage();
            MessagingCenter.Send(message, "ServiceStopped");
            UserMessage = "Location Service has been stopped!";
            SecureStorage.SetAsync(Constants.SERVICE_STATUS_KEY, "0");
            StartEnabled = true;
            StopEnabled = false;
        }

        void ValidateStatus() 
        {
            var status = SecureStorage.GetAsync(Constants.SERVICE_STATUS_KEY).Result;
            if (status != null && status.Equals("0")) 
            {
                Start();
            }
        }

        public async void Start() 
        {
            var message = new StartServiceMessage();

            var locationService = new XamarinForms.LocationService.Services.Location();

            await locationService.Run(System.Threading.CancellationToken.None);
            MessagingCenter.Send(message, "ServiceStarted");
            UserMessage = "Location Service has been started!";

            await SecureStorage.SetAsync(Constants.SERVICE_STATUS_KEY, "1");
            StartEnabled = true;
            StopEnabled = false;
        }

        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<LocationMessage>(this, "Location", message => {
                Device.BeginInvokeOnMainThread(() => {
                    Latitude = message.Lattitude;
                    Longitude = message.Longitude;
                    DriverName = this.DriverName;
                    DriverPhoneNumber = this.DriverPhoneNumber;
                    VehicleRegistration = this.VehicleRegistration;
                    userMessage = "Location Updated";
                    UpdatePhoneNumber = this.UpdatePhoneNumber;
                    //Call HttpClient EndPoint on Server updates of driver phone location
                    HttpClient httpClient = new HttpClient();
                   // httpClient.BaseAddress = new System.Uri("");
                    var content = new { DriverName = this.DriverName, DriverPhoneNumber = this.DriverPhoneNumber,
                        UpdatePhoneNumber = this.UpdatePhoneNumber,
                        VehicleRegistration = this.VehicleRegistration, Lattitude = message.Lattitude, Longitude = message.Longitude };
                    var jsonContent = JsonConvert.SerializeObject(content);
                    var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var res = httpClient.PostAsync("https://africanfarmerscommodities.martinlayooinc.com/VehicleSchedules/MonitorAndPlotVehicleOnMap", stringContent).ConfigureAwait(true).GetAwaiter().GetResult();
                });
            });
            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                Device.BeginInvokeOnMainThread(() => {
                    UserMessage = "Location Service has been stopped!";
                });
            });
            MessagingCenter.Subscribe<LocationErrorMessage>(this, "LocationError", message => {
                Device.BeginInvokeOnMainThread(() => {
                    UserMessage = "There was an error updating location!";
                });
            });
        }
    }
}
