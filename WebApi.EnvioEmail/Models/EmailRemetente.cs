using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.EnvioEmail.Models
{
    public class EmailRemetente
    {
        public int Id { get; set; }
        public string RemetenteEmail { get; set; }
        public string NameEmpresa { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public string Assunto { get; set; }
        public string Corpo { get; set; }

        [NotMapped]
        public string DestinatarioEmail { get; set; }
    }
}
