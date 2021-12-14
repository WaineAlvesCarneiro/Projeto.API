using System.ComponentModel.DataAnnotations;

namespace WebApi.XmlImportar.Models
{
    public class Cidades
    {
        [Key]
        public string Capital { get; set; }
        public decimal Population { get; set; }
    }
}
