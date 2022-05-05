using System;

namespace AfricanFarmerCommodities.Web.ViewModels
{
    public class DriverSchedulesNoteViewModle
    {
        public int DriveScheduleNoteId { get; set; }
        public string DriverNote { get; set; }
        public int TransportScheduleId { get; set; }
        public int DriverId { get; set; }
        public bool IsOriginNote { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
