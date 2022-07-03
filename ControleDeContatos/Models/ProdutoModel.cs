using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ProdutoModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Digite a descrição do produto")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o valor de custo do produto")]
        public double ValorCusto { get; set; }
        [Required(ErrorMessage = "Digite o valor de venda do produto")]
        public double ValorVenda { get; set; }
        [Required(ErrorMessage = "Digite o estoque do produto")]
        public double Estoque { get; set; }
        public bool? Excluido { get; set; }
    }
}
