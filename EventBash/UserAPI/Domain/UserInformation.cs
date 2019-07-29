using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Domain
{
    public class UserInformation
    {
        public int Id { get; set; } // Auto Generated...
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Organization { get; set; }
        public long PhoneNumber { get; set; }

        public string BillingAddress { get; set; }
        public long CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }

        public int PermissionId { get; set; }
        public virtual Permissions Permission { get; set; }
    }
}
