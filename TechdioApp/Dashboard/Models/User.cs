using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TechdioApp.Dashboard.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string University { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public string Role { get; set; }

        public User()
        {
            // Default constructor
        }

        // Optional: Parameterized constructor if you want to create a user with all properties at once
        public User(string id, string email, string name, string phone, string university, string location, string imageUrl)
        {
            Id = id;
            Email = email;
            Name = name;
            Phone = phone;
            University = university;
            Location = location;
            ImageUrl = imageUrl;
        }
    }
}