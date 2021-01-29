using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("Brands")]
    public class Brands
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum 100 character allowed.")]
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
