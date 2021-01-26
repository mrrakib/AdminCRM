using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First title is required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed")]
        public string TitleOne { get; set; }
        [Required(ErrorMessage = "Second title is required")]
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed")]
        public string TitleTwo { get; set; }
        [Required(ErrorMessage = "First tagline is required")]
        [MaxLength(150, ErrorMessage = "Maximum 150 character allowed")]
        public string TaglineOne { get; set; }
        [Required(ErrorMessage = "Second tagline is required")]
        [MaxLength(120, ErrorMessage = "Maximum 120 character allowed")]
        public string TaglineTwo { get; set; }
        [Required(ErrorMessage = "Button text is required")]
        [MaxLength(30, ErrorMessage = "Maximum 30 character allowed")]
        public string ButtonText { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum 200 character allowed")]
        public string ButtonLink { get; set; }
        public string ImagePath { get; set; }
    }
}
