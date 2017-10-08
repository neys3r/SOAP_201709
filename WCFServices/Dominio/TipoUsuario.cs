using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace WCFServices.Dominio
{
    [DataContract]
    public class TipoUsuario
    {
        [DataMember]
        public int cod_tipo { get; set; }
        [DataMember]
        public string nom_tipo { get; set; }

    }
}