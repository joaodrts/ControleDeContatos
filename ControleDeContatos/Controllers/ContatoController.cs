using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly iContatoRepositorio _contatoRepositorio;
        public ContatoController(iContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int ID)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorID(ID);
            return View(contato);
        }

        public IActionResult ExcluirConfirmacao(int ID)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorID(ID);
            return View(contato);
        }

        public IActionResult Excluir(int ID)
        {
            try
            {
                bool excluido = _contatoRepositorio.Excluir(ID);

                if (excluido)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops!, não foi possível excluir seu contato, tente novamente!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemSucesso"] = "Ops!, não foi possível excluir seu contato, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops!, não foi possível cadastrar seu contato, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.AlterarContato(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops!, não foi possível alterar seu contato, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
