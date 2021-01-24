using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("WorkProcessSection")]
    public class WorkProcessSection
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        [Required(ErrorMessage = "Top title is required.")]
        public string TopTitle { get; set; }
        [Required(ErrorMessage = "Main title is required.")]
        public string MainTitle { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Process icon is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        public string ProcessOneIcon { get; set; }
        [Required(ErrorMessage = "Process title is required.")]
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        public string ProcessOneTitle { get; set; }
        [Required(ErrorMessage = "Process description is required.")]
        public string ProcessOneDesc { get; set; }
        [Required(ErrorMessage = "Process icon is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        public string ProcessTwoIcon { get; set; }
        [Required(ErrorMessage = "Process title is required.")]
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        public string ProcessTwoTitle { get; set; }
        [Required(ErrorMessage = "Process description is required.")]
        public string ProcessTwoDesc { get; set; }
        public string ProcessThreeIcon { get; set; }
        [Required(ErrorMessage = "Process title is required.")]
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        public string ProcessThreeTitle { get; set; }
        [Required(ErrorMessage = "Process description is required.")]
        public string ProcessThreeDesc { get; set; }
    }
}
