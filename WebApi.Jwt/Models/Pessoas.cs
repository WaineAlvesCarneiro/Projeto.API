using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Jwt.Models
{
    public class Pessoas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Uf { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
    }
}
