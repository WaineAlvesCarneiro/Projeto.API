using System;

namespace WebApi.ImportarNfe.Models
{
    public class Duplicata
    {
        public int Id { get; set; }
        public string Chave { get; set; }

        public int qdDup { get; set; }
        //<cobr>
        // <dup>
        public double nDup { get; set; }
        public DateTime dVenc { get; set; }
        public decimal vDup { get; set; }
    }
}
