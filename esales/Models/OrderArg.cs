using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esales.Models
{
    public class OrderArg
    {
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public string OrderID { get; set; }
        public string CustName { get; set; }
        public string OrderDate { get; set; }
        public string EmployeeID { get; set; }
        public string CompanyName { get; set; }
    }
}