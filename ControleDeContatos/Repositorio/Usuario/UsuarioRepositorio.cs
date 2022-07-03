using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Usuario
{
    public class UsuarioRepositorio : iUsuarioRepositorio
    {
        private readonly BancoContext _BancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }
        public UsuarioModel BuscaPorEmail(string email)
        {

            var query = from user in _BancoContext.Usuarios
                        where user.Email == email
                        select user;

            return query.FirstOrDefault<UsuarioModel>();
        }

        public bool Registrar(UsuarioModel usuario)
        {
            UsuarioModel exist = BuscaPorEmail(usuario.Email);
            if (exist == null)
            {
                _BancoContext.Usuarios.Add(usuario);
                _BancoContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
