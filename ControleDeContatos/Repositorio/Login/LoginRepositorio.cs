using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Login
{
    public class LoginRepositorio : iLoginRepositorio
    {
        private readonly BancoContext _bancoContext;

        public LoginRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public bool Logar(UsuarioModel usuario)
        {
            var user = _bancoContext.Usuarios.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha).ToList();
            return user.Count > 0 ? true : false;
        }
    }
}
