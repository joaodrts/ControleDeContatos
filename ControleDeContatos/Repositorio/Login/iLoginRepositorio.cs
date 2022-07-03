using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio.Login
{
    public interface iLoginRepositorio
    {
        bool Logar(UsuarioModel usuario);
    }
}
