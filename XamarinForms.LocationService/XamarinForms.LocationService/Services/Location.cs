using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinForms.LocationService.Messages;

namespace XamarinForms.LocationService.Services
{
    public class Location
    {
		readonly bool stopping = false;
		public Location()
		{
			this.locationMessage = new LocationMessage();
		}
		public LocationMessage locationMessage { get; set; }
		public async Task Run(CancellationToken token)
		{
			await Task.Run(async () => {
				while (!stopping)
				{
					token.ThrowIfCancellationRequested();
					try
					{
						var request = new GeolocationRequest(GeolocationAccuracy.High);
						var location = await Geolocation.GetLocationAsync(request);
						if (location != null)
						{
							locationMessage.Lattitude = location.Latitude;
							locationMessage.Longitude = location.Longitude;

							MessagingCenter.Send<LocationMessage>(locationMessage, "Location");
						}
						await Task.Delay(10000);
					}
					catch (Exception ex)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							var errormessage = new LocationErrorMessage();
							MessagingCenter.Send<LocationErrorMessage>(errormessage, "LocationError");
						});
					}
				}
				return;
			}, token);
		}
	}
}
