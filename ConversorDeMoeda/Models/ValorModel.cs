using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConversorDeMoeda.Models
{
    public class ValorModel
    {
        [Required(ErrorMessage ="Insira uma valor.")]
        [RegularExpression("^[0-9]*(?:\\,[0-9]*)?$", ErrorMessage ="Apenas numeros seguidos de virgula. Ex: 10,00")]
        public string ValorDolar { get; set; }

        public string ValorReal { get; set; }

        public string ValorConvertido { get; set; }
    }
}
