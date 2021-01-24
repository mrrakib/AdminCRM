using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        [Required(ErrorMessage = "Top title is required.")]
        public string TopTitle { get; set; }
        [Required(ErrorMessage = "Main title is required.")]
        public string MainTitle { get; set; }
    }
}
