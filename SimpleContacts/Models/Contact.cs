using System.ComponentModel.DataAnnotations;

namespace SimpleContacts.Models
{
    public class Contact
    {

        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
