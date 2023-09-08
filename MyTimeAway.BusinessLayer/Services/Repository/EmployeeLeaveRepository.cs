using Microsoft.EntityFrameworkCore;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.DataLayer;
using MyTimeAway.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyTimeAway.BusinessLayer.Services.Repository
{
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly MyTimeAwayDbContext _dbContext;
        public EmployeeLeaveRepository(MyTimeAwayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeLeave> ApproveLeaveRequest(long id)
        {
            var leave = await _dbContext.EmployeeLeaves.FindAsync(id);
            try
            {
                leave.Status = "Approved";
                _dbContext.EmployeeLeaves.Update(leave);
                await _dbContext.SaveChangesAsync();
                return leave;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<EmployeeLeave> CancelLeaveRequest(long id)
        {
            var leave = await _dbContext.EmployeeLeaves.FindAsync(id);
            try
            {
                leave.Status = "Cancelled";
                _dbContext.EmployeeLeaves.Update(leave);
                await _dbContext.SaveChangesAsync();
                return leave;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<EmployeeLeave> CreateLeave(EmployeeLeave leaveModel)
        {
            try
            {
                var result = await _dbContext.EmployeeLeaves.AddAsync(leaveModel);
                await _dbContext.SaveChangesAsync();
                return leaveModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteLeaveById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.EmployeeLeaves.Single(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<EmployeeLeave> GetAllLeaves()
        {
            try
            {
                var result = _dbContext.EmployeeLeaves.
                OrderByDescending(x => x.Id).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<EmployeeLeave> GetLeaveById(long id)
        {
            try
            {
                return await _dbContext.EmployeeLeaves.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<EmployeeLeave> RejectLeaveRequest(long id)
        {
            var leave = await _dbContext.EmployeeLeaves.FindAsync(id);
            try
            {
                leave.Status = "Rejected";
                _dbContext.EmployeeLeaves.Update(leave);
                await _dbContext.SaveChangesAsync();
                return leave;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<EmployeeLeave>> SearchLeaves(string employeeId, string employeeName, int totalDays)
        {
            try
            {
                var query = _dbContext.EmployeeLeaves.AsQueryable();

                if (!string.IsNullOrEmpty(employeeId))
                {
                    query = query.Where(leave => leave.EmployeeId == employeeId);
                }

                if (!string.IsNullOrEmpty(employeeName))
                {
                    query = query.Where(leave => leave.EmployeeName.Contains(employeeName));
                }

                if (totalDays > 0)
                {
                    query = query.Where(leave => leave.TotalDays == totalDays);
                }

                var leaves = await query.ToListAsync();
                return leaves.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<EmployeeLeave> UpdateLeave(EmployeeLeaveViewModel model)
        {
            var leave = await _dbContext.EmployeeLeaves.FindAsync(model.Id);
            try
            {
                leave.EmployeeId = model.EmployeeId;
                leave.EmployeeName = model.EmployeeName;
                leave.EmployeePhone = model.EmployeePhone;
                leave.EmployeeEmail = model.EmployeeEmail;
                leave.ManagerEmail = model.ManagerEmail;
                leave.FromDate = model.FromDate;
                leave.ToDate = model.ToDate;
                leave.TotalDays = model.TotalDays;
                leave.Reason = model.Reason;
                leave.IsProcessed = model.IsProcessed;
                leave.Status = model.Status;

                _dbContext.EmployeeLeaves.Update(leave);
                await _dbContext.SaveChangesAsync();
                return leave;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}