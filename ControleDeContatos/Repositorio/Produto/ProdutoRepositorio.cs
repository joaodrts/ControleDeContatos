using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ProdutoRepositorio : iProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();

            return produto;
        }

        public ProdutoModel AlterarProduto(ProdutoModel produto)
        {
            ProdutoModel produtoDB = BuscaPorID(produto.ID);

            if (produtoDB.ID == 0) throw new Exception("Houve um erro na atualização do produto!");

            produtoDB.Descricao = produto.Descricao;
            produtoDB.ValorCusto = produto.ValorCusto;
            produtoDB.ValorVenda = produto.ValorVenda;
            produtoDB.Estoque = produto.Estoque;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;
        }

        public ProdutoModel BuscaPorID(int ID)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.ID == ID);
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.Where(x => x.Excluido == null).OrderBy(x => x.ID).ToList();
        }

        public bool Excluir(int ID)
        {
            ProdutoModel produtoDB = BuscaPorID(ID);

            if (produtoDB.ID == 0) throw new Exception("Ops!, ocorreu um problema na exclusão do produto, tente novamente!");

            produtoDB.Excluido = true;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
