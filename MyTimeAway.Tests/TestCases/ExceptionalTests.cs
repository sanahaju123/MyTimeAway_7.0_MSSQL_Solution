

using Moq;
using MyTimeAway.BusinessLayer.Interfaces;
using MyTimeAway.BusinessLayer.Services.Repository;
using MyTimeAway.BusinessLayer.Services;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.DataLayer;
using MyTimeAway.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MyTimeAway.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MyTimeAwayDbContext _dbContext;

        private readonly IEmployeeLeaveService _employeeLeaveService;
        public readonly Mock<IEmployeeLeaveRepository> employeeleaveservice = new Mock<IEmployeeLeaveRepository>();

        private readonly EmployeeLeave _employeeLeave;
        private readonly EmployeeLeaveViewModel _employeeLeaveViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _employeeLeaveService = new EmployeeLeaveService(employeeleaveservice.Object);

            _output = output;

            _employeeLeave = new EmployeeLeave
            {
                Id = 1,
                EmployeeId = "Emp1",
                EmployeeName = "Employee 1",
                EmployeeEmail = "emp1@gmail.com",
                ManagerEmail = "mng@gmail.com",
                EmployeePhone = "3452765423",
                FromDate = DateTime.UtcNow,
                ToDate = DateTime.UtcNow,
                TotalDays = 1,
                IsProcessed = false,
                Reason = "Sick Leave",
                Status = "Approved"
            };

            _employeeLeaveViewModel = new EmployeeLeaveViewModel
            {
                Id = 2,
                EmployeeId = "Emp2",
                EmployeeName = "Employee 2",
                EmployeeEmail = "emp2@gmail.com",
                ManagerEmail = "mng@gmail.com",
                EmployeePhone = "3452765423",
                FromDate = DateTime.UtcNow,
                ToDate = DateTime.UtcNow,
                TotalDays = 2,
                IsProcessed = false,
                Reason = "Casual Leave",
                Status = "Rejected"
            };
        }
    

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidLeaveIdIsPassed()
        {
            //Arrange
            bool res = false;
            _employeeLeave.EmployeeId= "0";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                if (result != null || result.EmployeeId !="0")
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidCancelLeaveIdIsPassed()
        {
            //Arrange
            bool res = false;
           long id= 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CancelLeaveRequest(id)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CancelLeaveRequest(id);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidRejectLeaveIdIsPassed()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.RejectLeaveRequest(id)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.RejectLeaveRequest(id);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidApproveLeaveIdIsPassed()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.ApproveLeaveRequest(id)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.ApproveLeaveRequest(id);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}