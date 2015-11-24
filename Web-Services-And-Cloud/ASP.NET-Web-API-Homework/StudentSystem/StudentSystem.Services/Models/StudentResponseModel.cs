namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentResponseModel
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}