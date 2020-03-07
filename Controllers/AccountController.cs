using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Models;

namespace MyCompany.Controllers
{
    /// <summary>
    /// Контрелер для авторизации
    /// </summary>
    [Authorize] //атрибут авторизации. Для этой области
    public class AccountController : Controller
    {
        //для оперирования пользователями в бд через контекст
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //в конструкторе передаем пользователей
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        //Метод для вызова вьюхи ввода логина
        [AllowAnonymous] // атрибут анонимного пользователя. юзер должен быть не авторизован
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl; //
            return View(new LoginViewModel()); //возвращаем модель с введеными данными(логин, пароль)
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid) //если все данные валидны
            {
                IdentityUser user = await userManager.FindByNameAsync(model.UserName); //ищем пользователя по имени изобьекта LoginViewModel model 
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    //попытка войти по паролю и логину переданной в моделе
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false); // последний параметр блокировка пользователя.(если пароль не известен)
                    if (result.Succeeded)// если успешно. Ошибок нет.
                    {
                        return Redirect(returnUrl ?? "/"); //перенаправляем пользователя по url. В ту точку в которую он бытался зайти в админку
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль"); //отправляем пользователю
            }
            return View(model); //отправляем в браузер
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}