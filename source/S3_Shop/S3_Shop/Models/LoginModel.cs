using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S3_Shop.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Please enter your valid username")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter your valid password")]
        [Display(Name ="Password")]
        public string Password { get; set; }
        public string RememberMe { get; set; }
    }
}