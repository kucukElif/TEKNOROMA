﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeknoromaUI.Areas.Manager.Models.ViewModels
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "İsim boş geçilemez.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim boş geçilemez.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre (Tekrar) boş geçilemez.")]
        [Compare("Password", ErrorMessage = ("Şifreler uyuşmuyor"))]
        public string RepeatPassword { get; set; }
    }
}
