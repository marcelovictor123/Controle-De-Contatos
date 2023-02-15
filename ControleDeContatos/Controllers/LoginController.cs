using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
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
                  UsuarioModel usuario =  _usuarioRepositorio.BuscarPorLogin(loginModel.Login);


                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"senha invalida. Tente novamente";

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
