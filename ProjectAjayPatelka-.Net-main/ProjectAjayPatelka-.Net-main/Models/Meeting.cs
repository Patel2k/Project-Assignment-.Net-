using System.ComponentModel.DataAnnotations;

namespace MeetingManagment.Models
{
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }
        [Required]
        public string  MeetingDetails { get; set; }=string.Empty;
        [Required]
        [DataType(DataType.Date)] 
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int? RoomId { get; set; }
        public virtual Room? Room { get; set; }

    }
}
