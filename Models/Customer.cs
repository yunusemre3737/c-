using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EmaillAddress { get; set; } = null!;

    }
}
