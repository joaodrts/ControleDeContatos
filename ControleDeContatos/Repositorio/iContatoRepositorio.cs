using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface iContatoRepositorio
    {
        ContatoModel BuscarPorID(int ID);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel Contato);
        ContatoModel AlterarContato(ContatoModel contato);
        bool Excluir(int ID);
    }
}
