using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomm.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Fullname")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
