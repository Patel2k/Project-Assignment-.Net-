using Microsoft.EntityFrameworkCore;

namespace MeetingManagment.Models
{
    public class MeetingRoomDbcontext :DbContext
    {
        public MeetingRoomDbcontext(DbContextOptions<MeetingRoomDbcontext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
