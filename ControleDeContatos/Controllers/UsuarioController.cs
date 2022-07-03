using ControleDeContatos.Models;
using ControleDeContatos.Repositorio.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly iUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(iUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadastrou = _usuarioRepositorio.Registrar(usuario);
                    if (cadastrou)
                    {
                        TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Este email já está sendo utilizado!";
                    }
                }

                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops!, não foi possível cadastrar seu usuário, tente novamente!" + " Error: " + error.Message;
                return View(usuario);
            }
        }
    }
}
