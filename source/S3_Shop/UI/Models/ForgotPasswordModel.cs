using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Vui lòng nhập email xác nhận.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Vui lòng nhập email hợp lệ")]
        public string Email { get; set; }

        public bool SendReminderSuccess { get; set; } = false;
    }
}