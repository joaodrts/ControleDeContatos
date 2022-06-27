using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface iProdutoRepositorio
    {
        List<ProdutoModel> BuscarTodos();
    }
}
