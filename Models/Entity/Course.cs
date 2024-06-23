using System.ComponentModel.DataAnnotations;

namespace BDolma_SMS.Models.Entity
{
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "Please Enter Course Name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
