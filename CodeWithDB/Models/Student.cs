using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWithDB.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("Student Name",TypeName = "varchar(40)")]
        [Required]
        public string Name { get; set; }

        [Column("Student Gender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public int? Standard { get; set; }

        [Column("Student Hobbies", TypeName = "varchar(300)")]
        public List<string> SelectedHobbies { get; set; }
     }
}
