using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi.Repositories.Models
{
    public enum Role
    {
        Player,
        Moderator,
        Admin
    }
    public class User
    {
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public decimal Balance { get; set; }
        public Role UserRole { get; set; }
      
        


    }
}
