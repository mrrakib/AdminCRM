using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminCRM.Model.Models.CompanyDetails
{
    [Table("CompanySocialProfile")]
    public class CompanySocialProfile
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Profile name is a required field.")]
        [StringLength(30, ErrorMessage = "Maximum 30 character allowed.")]
        public string ProfileName { get; set; }
        [Required(ErrorMessage = "Profile link is a required field.")]
        [StringLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        public string ProfileLink { get; set; }
        [Required(ErrorMessage = "Profile icon is a required field.")]
        [StringLength(30, ErrorMessage = "Maximum 30 character allowed.")]
        public string ProfileIcon { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}
