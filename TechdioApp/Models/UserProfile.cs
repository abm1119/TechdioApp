using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechdioApp.Models
{
    public class UserProfile
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Institute { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
