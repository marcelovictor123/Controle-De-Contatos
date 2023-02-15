using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"Usuario e/ou senha invalido(s). Tente novamente";


                }
                return View("Index");

            }
            catch(Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, erro ao realizar login.{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
