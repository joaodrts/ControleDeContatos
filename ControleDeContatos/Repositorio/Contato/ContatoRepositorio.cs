using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : iContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public bool Excluir(int ID)
        {
            ContatoModel contatoDB = BuscarPorID(ID);

            if (contatoDB.ID == 0) throw new Exception("Houve um erro na exclusão do contato!");

            contatoDB.Excluido = true;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return true;

        }

        public ContatoModel AlterarContato(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorID(contato.ID);

            if ( contatoDB.ID == 0 ) throw new Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public ContatoModel BuscarPorID(int ID)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.ID == ID);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.Where(x => x.Excluido == null).OrderBy(x => x.ID).ToList();
        }

        public ContatoModel Adicionar(ContatoModel Contato)
        {
            _bancoContext.Contatos.Add(Contato);
            _bancoContext.SaveChanges();
        
            return Contato;
        }

    }
}
