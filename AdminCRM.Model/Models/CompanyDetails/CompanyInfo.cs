using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminCRM.Model.Models.CompanyDetails
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(20, ErrorMessage = "Maximum 20 character allowed.")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string Email { get; set; }
        [StringLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string WelcomeText { get; set; }
        [StringLength(150, ErrorMessage = "Maximum 150 character allowed.")]
        public string CopyrightText { get; set; }
        [StringLength(250, ErrorMessage = "Maximum 250 character allowed.")]
        public string CompanyLogoPath { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum 200 character allowed.")]
        [Required(ErrorMessage = "Short description is required.")]
        [DefaultValue("")]
        public string CompanyShortDescription { get; set; }
    }
}
