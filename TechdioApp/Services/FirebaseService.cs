using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechdioApp.Dashboard.Models;

namespace TechdioApp.Services
{
    public class FirebaseService
    {
        
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            _firebaseClient = new FirebaseClient("Your-Firebase-DatabaseURL-key-here/");
        }
        // Existing method to get all users
        // Method to get all users
        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            return users.Select(item => new User
            {
                Id = item.Key,
                Name = item.Object.Name,
                Email = item.Object.Email,
                Phone = item.Object.Phone,
                University = item.Object.University,
                Location = item.Object.Location,
                ImageUrl = item.Object.ImageUrl
            }).ToList();
        }

        // Method to get a user by their UID (for profile editing)
        public async Task<User> GetUserAsync(string userId)
        {
            var user = (await _firebaseClient
                .Child("Users")
                .Child(userId)
                .OnceSingleAsync<User>());
            return user;
        }

        // Method to get a user by email (optional)
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var users = await _firebaseClient
                .Child("Users")
                .OnceAsync<User>();

            var user = users
                .FirstOrDefault(u => u.Object.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return user?.Object;
        }

        // Method to save a user to Firebase
        public async Task SaveUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                var newUser = await _firebaseClient.Child("Users").PostAsync(user);
                user.Id = newUser.Key;
            }
            else
            {
                await _firebaseClient.Child("Users").Child(user.Id).PutAsync(user);
            }
        }

        // Method to delete a user from Firebase
        public async Task DeleteUserAsync(string userId)
        {
            await _firebaseClient.Child("Users").Child(userId).DeleteAsync();
        }
    }
}
