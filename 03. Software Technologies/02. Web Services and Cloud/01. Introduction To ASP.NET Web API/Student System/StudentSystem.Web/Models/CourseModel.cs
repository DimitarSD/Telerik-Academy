namespace StudentSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}