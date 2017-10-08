using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class TipoDocumento
    {
        [DataMember]
        public int cod_tipodoc { get; set; }

        [DataMember]
        public string nom_tipodoc { get; set; }


    }
}