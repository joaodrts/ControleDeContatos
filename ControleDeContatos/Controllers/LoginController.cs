using ControleDeContatos.Models;
using ControleDeContatos.Repositorio.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly iLoginRepositorio _loginRepositorio;

        public LoginController(iLoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Logar(UsuarioModel usuario)
        {
            bool isLogar =_loginRepositorio.Logar(usuario);
            if (isLogar)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                TempData["MensagemErro"] = "Nenhum usuário encontrado com essas informações!";
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
