using MeetingManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_controller : ControllerBase
    {
        private readonly MeetingRoomDbcontext _component;

        public Employee_controller(MeetingRoomDbcontext component)
        {
            _component = component;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employee = await _component.Employees.ToListAsync();
            return Ok(employee);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeebyId(int id)
        {
            var select = await _component.Employees.FindAsync(id);
            return Ok(select);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddFooditem(Employee emp)
        {
            _component.Employees.Add(emp);
            await _component.SaveChangesAsync();
            return CreatedAtAction("GetEmoloyee", new { id = emp.EmployeeId}, emp);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, Employee emp)
        {
            var men = await _component.Employees.FindAsync(id);
            if (men == null)
            {
                throw new Exception("Employee not found to update");
            }
            else
            {
                men.EmployeeEmail = emp.EmployeeEmail;
                men.EmployeePhone= emp.EmployeePhone;
                men.EmployeeName = emp.EmployeeName;
                men.AdminID= emp.AdminID;
                men.Admin= emp.Admin;
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
                throw new Exception("EmpId not Found");
            }
            return NoContent();
        }
        private bool EmployeeExists(int id)
        {
            return _component.Employees.Any(mi => mi.EmployeeId == id);
        }
    }
}
