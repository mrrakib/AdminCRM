using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Model.Models.Sections
{
    [Table("ContactUs")]
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum 200 character allowed.")]
        [Required(ErrorMessage = "Location title is required.")]
        public string LocationTitle { get; set; }
        [MaxLength(300, ErrorMessage = "Maximum 300 character allowed.")]
        [Required(ErrorMessage = "Location address is required.")]
        public string LocationAddress { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Location icon is required.")]
        public string LocationIcon { get; set; }
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        [Required(ErrorMessage = "Phone title is required.")]
        public string PhoneTitle { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum 20 character allowed.")]
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Phone icon is required.")]
        public string PhoneIcon { get; set; }
        [MaxLength(80, ErrorMessage = "Maximum 80 character allowed.")]
        [Required(ErrorMessage = "Mail Title is required.")]
        public string MailTitle { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum 100 character allowed.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 character allowed.")]
        [Required(ErrorMessage = "Mail icon is required.")]
        public string MailIcon { get; set; }
    }
}
