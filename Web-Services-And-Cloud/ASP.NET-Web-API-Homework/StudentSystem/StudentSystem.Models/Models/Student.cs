namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        private HashSet<Course> courses;
        private HashSet<Homework> homeworks;
        private HashSet<Student> trainees;

        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Trainees = new HashSet<Student>();
            this.AdditionalInformation = new AdditionalInformation();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The student's first name cannot exceed 30 characters.")]
        [MinLength(2, ErrorMessage = "The student's first name cannot be less than 2 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The student's last name cannot exceed 30 characters.")]
        [MinLength(2, ErrorMessage = "The student's last name cannot be less than 2 characters.")]
        public string LastName { get; set; }

        public AdditionalInformation AdditionalInformation { get; set; }

        public virtual Student Assistant { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainees
        {
            get { return this.trainees; }
            set { this.trainees = (HashSet<Student>)value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = (HashSet<Course>)value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = (HashSet<Homework>)value; }
        }

        [NotMapped]
        public bool IsAssistant
        {
            get { return this.Trainees.Count > 0; }
        }
    }
}
