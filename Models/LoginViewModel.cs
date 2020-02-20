using System.ComponentModel.DataAnnotations;

namespace MyCompany.Models
{
    /// <summary>
    /// Вьюха для ввода логина и пароля
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
        //Чекбокс
    }
}
