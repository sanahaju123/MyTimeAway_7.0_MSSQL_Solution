
using Moq;
using MyTimeAway.BusinessLayer.Interfaces;
using MyTimeAway.BusinessLayer.Services;
using MyTimeAway.BusinessLayer.Services.Repository;
using MyTimeAway.BusinessLayer.ViewModels;
using MyTimeAway.DataLayer;
using MyTimeAway.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MyTimeAway.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MyTimeAwayDbContext _dbContext;

        private readonly IEmployeeLeaveService _employeeLeaveService;
        public readonly Mock<IEmployeeLeaveRepository> employeeleaveservice = new Mock<IEmployeeLeaveRepository >();

        private readonly EmployeeLeave _employeeLeave;
        private readonly EmployeeLeaveViewModel _employeeLeaveViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _employeeLeaveService = new EmployeeLeaveService(employeeleaveservice.Object);
           
            _output = output;

            _employeeLeave = new EmployeeLeave
            {
               Id=1,
               EmployeeId="Emp1",
               EmployeeName="Employee 1",
               EmployeeEmail="emp1@gmail.com",
               ManagerEmail="mng@gmail.com",
               EmployeePhone="3452765423",
               FromDate=DateTime.UtcNow,
               ToDate=DateTime.UtcNow,
               TotalDays=1,
               IsProcessed=false,
               Reason="Sick Leave",
               Status="Approved"
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
        public async Task<bool> Testfor_Create_Leave()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.CreateLeave(_employeeLeave)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.CreateLeave(_employeeLeave);
                //Assertion
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
        public async Task<bool> Testfor_Update_Leave()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.UpdateLeave(_employeeLeaveViewModel)).ReturnsAsync(_employeeLeave); 
                var result = await _employeeLeaveService.UpdateLeave(_employeeLeaveViewModel);
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
        public async Task<bool> Testfor_Cancel_Leave()
        {
            //Arrange
            bool res = false;
            long id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.CancelLeaveRequest(id)).ReturnsAsync(_employeeLeave);
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
        public async Task<bool> Testfor_Reject_Leave()
        {
            //Arrange
            bool res = false;
            long id = 2;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.RejectLeaveRequest(id)).ReturnsAsync(_employeeLeave);
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
        public async Task<bool> Testfor_Approve_Leave()
        {
            //Arrange
            bool res = false;
            long id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.ApproveLeaveRequest(id)).ReturnsAsync(_employeeLeave);
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

        
        [Fact]
        public async Task<bool> Testfor_GetLeaveById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.GetLeaveById(id)).ReturnsAsync(_employeeLeave);
                var result = await _employeeLeaveService.GetLeaveById(id);
                //Assertion
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
        public async Task<bool> Testfor_DeleteLeaveById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                employeeleaveservice.Setup(repos => repos.DeleteLeaveById(id)).ReturnsAsync(response);
                var result = await _employeeLeaveService.DeleteLeaveById(id);
                //Assertion
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