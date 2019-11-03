using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerDataViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customers customer { get; set; }
    }
}