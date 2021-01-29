using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("FeatureSingle")]
    public class FeatureSingle
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public string ImagePath { get; set; }
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string ImageName { get; set; }
    }
}
