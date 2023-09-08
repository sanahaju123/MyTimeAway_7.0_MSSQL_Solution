using MyTimeAway.BusinessLayer.Interfaces;
using MyTimeAway.BusinessLayer.Services.Repository;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeAway.BusinessLayer.Services
{
    public class EmployeeLeaveService : IEmployeeLeaveService
    {
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;

        public EmployeeLeaveService(IEmployeeLeaveRepository employeeLeaveRepository)
        {
            _employeeLeaveRepository = employeeLeaveRepository;
        }

        public async Task<EmployeeLeave> ApproveLeaveRequest(long id)
        {
            return await _employeeLeaveRepository.ApproveLeaveRequest(id);
        }

        public async Task<EmployeeLeave> CancelLeaveRequest(long id)
        {
            return await _employeeLeaveRepository.CancelLeaveRequest(id);
        }

        public async Task<EmployeeLeave> CreateLeave(EmployeeLeave employeeLeave)
        {
            return await _employeeLeaveRepository.CreateLeave(employeeLeave);
        }

        public async Task<bool> DeleteLeaveById(long id)
        {
            return await _employeeLeaveRepository.DeleteLeaveById(id);
        }

        public List<EmployeeLeave> GetAllLeaves()
        {
            return  _employeeLeaveRepository.GetAllLeaves();
        }

        public async Task<EmployeeLeave> GetLeaveById(long id)
        {
            return await _employeeLeaveRepository.GetLeaveById(id);
        }

        public async Task<EmployeeLeave> RejectLeaveRequest(long id)
        {
            return await _employeeLeaveRepository.RejectLeaveRequest(id);
        }

        public async Task<List<EmployeeLeave>> SearchLeaves(string employeeId, string employeeName, int totalDays)
        {
            return await _employeeLeaveRepository.SearchLeaves(employeeId, employeeName, totalDays);
        }

        public async Task<EmployeeLeave> UpdateLeave(EmployeeLeaveViewModel model)
        {
           return await _employeeLeaveRepository.UpdateLeave(model);
        }
    }
}
