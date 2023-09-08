using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTimeAway.BusinessLayer.Interfaces;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeAway.Controllers
{
    [ApiController]
    public class EmployeeLeaveController : ControllerBase
    {
        private readonly IEmployeeLeaveService _employeeLeaveService;
        public EmployeeLeaveController(IEmployeeLeaveService employeeLeaveService)
        {
            _employeeLeaveService = employeeLeaveService;
        }

        [HttpPost]
        [Route("create-leave")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateLeave([FromBody] EmployeeLeave model)
        {
            var leaveExists = await _employeeLeaveService.GetLeaveById(model.Id);
            if (leaveExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Leave already exists!" });
            var result = await _employeeLeaveService.CreateLeave(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Leave creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Leave created successfully!" });

        }


        [HttpPut]
        [Route("update-leave")]
        public async Task<IActionResult> UpdateLeave([FromBody] EmployeeLeaveViewModel model)
        {
            var leave = await _employeeLeaveService.UpdateLeave(model);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {model.Id} cannot be found" });
            }
            else
            {
                var result = await _employeeLeaveService.UpdateLeave(model);
                return Ok(new Response { Status = "Success", Message = "Leave updated successfully!" });
            }
        }

        [HttpPut]
        [Route("cancel-leave")]
        public async Task<IActionResult> CancelLeave(long id)
        {
            var leave = await _employeeLeaveService.CancelLeaveRequest(id);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _employeeLeaveService.CancelLeaveRequest(id);
                return Ok(new Response { Status = "Success", Message = "Leave cancelled successfully!" });
            }
        }

        [HttpPut]
        [Route("approve-leave")]
        public async Task<IActionResult> ApproveLeave(long id)
        {
            var leave = await _employeeLeaveService.ApproveLeaveRequest(id);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _employeeLeaveService.ApproveLeaveRequest(id);
                return Ok(new Response { Status = "Success", Message = "Leave approved successfully!" });
            }
        }

        [HttpPut]
        [Route("reject-leave")]
        public async Task<IActionResult> RejectLeave(long id)
        {
            var leave = await _employeeLeaveService.RejectLeaveRequest(id);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _employeeLeaveService.RejectLeaveRequest(id);
                return Ok(new Response { Status = "Success", Message = "Leave rejected successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-leave")]
        public async Task<IActionResult> DeleteLeave(long id)
        {
            var leave = await _employeeLeaveService.GetLeaveById(id);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _employeeLeaveService.DeleteLeaveById(id);
                return Ok(new Response { Status = "Success", Message = "Leave deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-leave-by-id")]
        public async Task<IActionResult> GetLeaveById(long id)
        {
            var leave = await _employeeLeaveService.GetLeaveById(id);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(leave);
            }
        }

        [HttpGet]
        [Route("search-leaves")]
        public async Task<IActionResult> SearchLeaves(string employeeId,string employeeName,int totalDays)
        {
            var leave = await _employeeLeaveService.SearchLeaves(employeeId,employeeName,totalDays);
            if (leave == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Leave With Id = {employeeId} cannot be found" });
            }
            else
            {
                return Ok(leave);
            }
        }


        [HttpGet]
        [Route("get-all-leaves")]
        public async Task<IEnumerable<EmployeeLeave>> GetAllLeaves()
        {
            return  _employeeLeaveService.GetAllLeaves();
        }
    }
}
