using System.ComponentModel.DataAnnotations;

namespace MeetingManagment.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }=string.Empty;
        [Required]
        public int RoomCapacity { get; set;}
        [Required]
        public string RoomLocation { get; set; } = string.Empty;
    }
}
