using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIdbcon.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Character limit exceeding (maximum characters should be 30)")]
        public string name { get; set; }
        [Required]
        public string cnic { get; set; }
        [Required]
        [Range(1, 12, ErrorMessage = "Semesters should be in between 1 - 12")]
        public int semester { get; set; }
        [Required]
        [Range(0.0,4.0,ErrorMessage ="CGPA should be in between 0.0 - 4.0")]
        public float cgpa { get; set; }

    }
}
