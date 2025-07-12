using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechdioApp.Models;

namespace TechdioApp.Services
{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuthClient _authClient;

        public FirebaseAuthService(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        public UserModel GetLoggedInUser()
        {
            var user = _authClient.User?.Info;
            return user != null ? new UserModel
            {
                UserName = user.DisplayName ?? "User",
                UserEmail = user.Email,
                UserRole = "Student"
            } : null;
        }

        public void SignOut()
        {
            _authClient.SignOut();
        }
    }
}

