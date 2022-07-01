using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage ="O celular informado é inválido")]
        public string Celular { get; set; }
        public bool? Excluido { get; set; }
    }
}
