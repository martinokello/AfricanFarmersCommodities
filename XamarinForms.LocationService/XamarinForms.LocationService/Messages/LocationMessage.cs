namespace XamarinForms.LocationService.Messages
{
    public class LocationMessage
    {
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public string DriverName { get; set; }
        public bool UpdatePhoneNumber { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string VehicleRegistration { get; set; }
    }
}
