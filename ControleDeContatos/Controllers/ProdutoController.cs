using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly iProdutoRepositorio _produtoRepositorio;
        public ProdutoController(iProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = "Ops!, não foi possível cadastrar seu produto, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.AlterarProduto(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", produto);

            } catch(Exception error)
            {
                TempData["MensagemErro"] = "Ops!, não foi possível alterar o cadastro do produto, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int ID)
        {
            ProdutoModel produto = _produtoRepositorio.BuscaPorID(ID);
            return View(produto);
        }

        public IActionResult Excluir(int ID)
        {
            try
            {
                bool excluido = _produtoRepositorio.Excluir(ID);

                if (excluido)
                {
                    TempData["MensagemSucesso"] = "Produto excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops!, ocorreu um problema na exclusão do produto, tente novamente!";
                }

                return RedirectToAction("Index");

            }catch(Exception error)
            {
                TempData["MensagemErro"] = "Ops!, ocorreu um problema na exclusão do produto, tente novamente!" + " Error: " + error.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult ExcluirConfirmacao(int ID)
        {
            ProdutoModel produto = _produtoRepositorio.BuscaPorID(ID);
            return View(produto);
        }
    }
}
