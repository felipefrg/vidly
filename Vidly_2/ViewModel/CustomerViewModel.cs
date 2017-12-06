using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;

namespace Vidly_2.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerModel Customer { get; set; }
        public IList<MembershipTypeModel> LstMembershipType { get; set; }
    }
}