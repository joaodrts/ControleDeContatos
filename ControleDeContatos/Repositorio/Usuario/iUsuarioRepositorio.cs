using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Usuario
{
    public interface iUsuarioRepositorio
    {
        public UsuarioModel BuscaPorEmail(string email);
        public bool Registrar(UsuarioModel usuario);

    }
}
