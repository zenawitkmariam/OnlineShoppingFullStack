using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCounselling.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string MiddleName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [MaxLength(250)]
        public string UserNumber { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string PhoneNumber { get; set; }
        [MaxLength(250)]
        public string EmailAddress { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; }
        public string ImageUrl { get; set; }
    }
}
