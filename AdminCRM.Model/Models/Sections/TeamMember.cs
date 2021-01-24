using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("TeamMember")]
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(80, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Facebook { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Twitter { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Tumblr { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Vimeo { get; set; }
        public string ImagePath { get; set; }
    }
}
