using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("ExperienceSection")]
    public class ExperienceSection
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        [Required(ErrorMessage = "Top title is required.")]
        public string TopTitle { get; set; }
        [Required(ErrorMessage = "Main title is required.")]
        public string MainTitle { get; set; }
        [Required(ErrorMessage = "Description title is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Experience Percentage is required.")]
        public int ExperiencePercentage { get; set; }
        [Required(ErrorMessage = "Project Percentage is required.")]
        public int ProjectPercentage { get; set; }
        [Required(ErrorMessage = "Support Percentage is required.")]
        public int SupportPercentage { get; set; }
        [Required(ErrorMessage = "Clean Percentage is required.")]
        public int CleanPercentage { get; set; }

    }
}
