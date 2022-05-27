using Newtonsoft.Json;
using System;

namespace Clientes.Domain.Entities
{
    public class Cliente
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("dataAdmissao")]
        public DateTime DataAdmissao { get; set; }

        [JsonProperty("salario")]
        public decimal Salario { get; set; }

        [JsonProperty("comissao")]
        public decimal Comissao { get; set; }

        [JsonProperty("dataInclusao")]
        public DateTime DataInclusao { get; set; }

        [JsonProperty("dataAlteracao")]
        public DateTime DataAlteracao { get; set; }
    }
}
