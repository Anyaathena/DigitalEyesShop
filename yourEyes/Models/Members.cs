using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Members
    {
        [DisplayName("會員帳號")]
        [RegularExpression(@"^09[0-9]{8}$", ErrorMessage = "手機號碼格式不符")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "長度不正確")]
        [Remote("AccountCheck", "Members", ErrorMessage = "此帳號已被註冊過")]
        [Required(ErrorMessage = "請輸入手機")]
        //帳號
        public string Account { get; set; }
        //密碼
        public string Password { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "請輸入Email")]
        [StringLength(200, ErrorMessage = "Email長度最多200字元")]
        [EmailAddress(ErrorMessage = "這不是Email格式")]
        //電子信箱
        public string Email { get; set; }
        //信箱驗證碼
        public string AuthCode { get; set; }
        //管理者
        public bool IsAdmin { get; set; }
        [DisplayName("姓名")]
        [StringLength(20, ErrorMessage = "姓名長度最多20字元")]
        [Required(ErrorMessage = "請輸入姓名")]
        //姓名
        public string Name { get; set; }
        [DisplayName("市話")]
        [Required(ErrorMessage = "請輸入市話")]
        public string MyPhone { get; set; }
        [DisplayName("地址")]
        [Required(ErrorMessage = "請輸入地址")]
        public string MyAddress { get; set; }

    }

}