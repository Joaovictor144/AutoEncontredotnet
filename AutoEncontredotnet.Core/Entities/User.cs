using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoEncontredotnet.Entities
{
	[Table("User")]
	public class User
	{
        public User(string name, string username, string password, string phoneNumber, int permissionId, int storeId)
        {
            Name = name;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            PermissionId = permissionId;
            StoreId = storeId;
            isDeleted = false;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        [Key]

		public int Id { get; private set; }

		public string Name { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string PhoneNumber { get; set; }

		public int PermissionId { get; set; }

		public int StoreId { get; set; }

        public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; set; }

		public bool isDeleted { get; set; }

    }
}

