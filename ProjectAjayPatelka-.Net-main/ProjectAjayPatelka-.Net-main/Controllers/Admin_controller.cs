using MeetingManagment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_controller : ControllerBase
    {
        private readonly MeetingRoomDbcontext _component;

        public Admin_controller(MeetingRoomDbcontext component)
        {
            _component = component;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmin()
        {
            var admin = await _component.Admins.ToListAsync();
            return Ok(admin);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminBy(int id)
        {
            var select = await _component.Admins.FindAsync(id);
            return Ok(select);
        }
        [HttpPost]
        public async Task<ActionResult<Admin>> AddFooditem(Admin admin)
        {
            _component.Admins.Add(admin);
            await _component.SaveChangesAsync();
            return CreatedAtAction("GetAdmin", new { id = admin.AdminId }, admin);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, Admin admin)
        {
            var men = await _component.Admins.FindAsync(id);
            if (men == null)
            {
                throw new Exception("Admin not found to update");
            }
            else
            {
                men.AdminName = admin.AdminName;
                men.AdminPhone = admin.AdminPhone;
                men.AdminEmail = admin.AdminEmail;
                men.AdminPassword = admin.AdminPassword;    
                await _component.SaveChangesAsync();
                return Ok(men);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _component.Admins.FindAsync(id);
            if (menu != null)
            {
                _component.Admins.Remove(menu);
                _component.SaveChanges();
            }
            else
            {
                throw new Exception("Id not Found");
            }
            return NoContent();
        }
        private bool AdminExists(int id)
        {
            return _component.Admins.Any(mi => mi.AdminId == id);
        }

    }
}
