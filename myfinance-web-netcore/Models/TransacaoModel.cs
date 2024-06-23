using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace myfinance_web_netcore.Models{
    public class TransacaoModel{
        public int? Id {get; set;}
        public string? Historico {get; set;}
        public DateTime Data {get;set;}

        [Required(ErrorMessage ="Informe o valor da Transação")]
        [Range(0.01, 9999999999999999999.99, ErrorMessage ="Informe um valor maior que 0")]
        public decimal Valor {get;set;}
        public int PlanoContaId {get;set;}
        
        public PlanoContaModel? ItemPlanoConta {get; set;}
        public IEnumerable<SelectListItem>? PlanoContas {get; set;}
    }
}