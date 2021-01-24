using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("ServiceSingle")]
    public class ServiceSingle
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Icon is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 character allowed.")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Description { get; set; }
    }
}
