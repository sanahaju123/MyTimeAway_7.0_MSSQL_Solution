using System;
using System.Collections.Generic;
using System.Text;

namespace MyTimeAway.BusinessLayer.ViewModels
{
    public class EmployeeLeaveViewModel
    {
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string ManagerEmail { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public bool IsProcessed { get; set; } = false;
        public string Status { get; set; } = "";
    }
}
