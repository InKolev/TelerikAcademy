namespace StudentSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseResponseModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}