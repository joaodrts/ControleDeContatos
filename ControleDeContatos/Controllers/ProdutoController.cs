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
            List<ProdutoModel> produto = _produtoRepositorio.BuscarTodos();
            return View(produto);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
