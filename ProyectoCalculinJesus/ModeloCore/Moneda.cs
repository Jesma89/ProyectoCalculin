using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Modelo
{[DataContract]
    public class Moneda
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Abreviatura { get; set; } // EUR
        [DataMember]
        public string Nombre { get; set; } // EUROS

    }
}