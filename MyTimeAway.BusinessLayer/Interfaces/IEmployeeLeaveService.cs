using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTimeAway.BusinessLayer.Interfaces
{
    public interface IEmployeeLeaveService
    {
        List<EmployeeLeave> GetAllLeaves();
        Task<EmployeeLeave> CreateLeave(EmployeeLeave employeeLeave);
        Task<EmployeeLeave> GetLeaveById(long id);
        Task<List<EmployeeLeave>> SearchLeaves(string employeeId, string employeeName, int totalDays);
        Task<bool> DeleteLeaveById(long id);
        Task<EmployeeLeave> UpdateLeave(EmployeeLeaveViewModel model);
        Task<EmployeeLeave> CancelLeaveRequest(long id);
        Task<EmployeeLeave> ApproveLeaveRequest(long id);
        Task<EmployeeLeave> RejectLeaveRequest(long id);
    }
}
