
using Moq;
using MyTimeAway.BusinessLayer.Interfaces;
using MyTimeAway.BusinessLayer.Services.Repository;
using MyTimeAway.BusinessLayer.Services;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.DataLayer;
using MyTimeAway.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MyTimeAway.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MyTimeAwayDbContext _dbContext;

        private readonly IEmployeeLeaveService _employeeLeaveService;
        public readonly Mock<IEmployeeLeaveRepository> employeeleaveservice = new Mock<IEmployeeLeaveRepository>();

        private readonly EmployeeLeave _employeeLeave;
        private readonly EmployeeLeaveViewModel _employeeLeaveViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Employee_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                var actualLength = _employeeLeave.EmployeeName.ToString().Length;
                if (result.EmployeeName.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Employee_Email_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                var actualLength = _employeeLeave.EmployeeEmail.ToString().Length;
                if (result.EmployeeEmail.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Employee_Phone_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                var actualLength = _employeeLeave.EmployeePhone.ToString().Length;
                if (result.EmployeePhone.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Manager_Email_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repo => repo.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                var actualLength = _employeeLeave.ManagerEmail.ToString().Length;
                if (result.ManagerEmail.ToString().Length == actualLength)
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