using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public int LoginId { get; set; }
    }
}
