using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string NumeroDoc { get; set; }
        [DataMember]
        public string NomUsuario { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        


    }
}