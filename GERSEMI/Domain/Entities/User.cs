using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        public string? Phone { get; private set; }
        public string? Address { get; private set; }
        public string? City { get; private set; }
        public string? ZipCode { get; private set; }
        public string? Country { get; private set; }

        public bool IsAdmin { get; private set; }
        public bool IsEmployee { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private User() { }

        public User(
            string email,
            string passwordHash,
            bool isAdmin = false,
            bool isEmployee = false)
        {
            Email = email;
            PasswordHash = passwordHash;
            IsAdmin = isAdmin;
            IsEmployee = isEmployee;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(string newHash)
        {
            PasswordHash = newHash;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
