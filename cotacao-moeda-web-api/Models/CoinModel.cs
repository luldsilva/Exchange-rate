using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cotacao_moeda_web_api.Models
{
    public class CoinModel
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [StringLength(80)]
        public string coin { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public DateTime date_begin { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public DateTime date_final { get; set; }

    }
}
