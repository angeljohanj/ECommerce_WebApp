using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class UsersModel
    {
        public int UsersId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool RestoreUser { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
