using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
