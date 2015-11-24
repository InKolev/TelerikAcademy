namespace StudentSystem.Services.Models
{
    using System;

    public class HomeworkResponseModel
    {
        public int ID { get; set; }

        public string Tasks { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime Deadline { get; set; }

        public virtual int CourseID { get; set; }
    }
}
