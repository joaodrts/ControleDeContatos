using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Informe o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage ="Informe o email do usuário")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Informe a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool? Excluido { get; set; }
    }
}
