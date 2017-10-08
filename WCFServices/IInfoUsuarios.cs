using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;

namespace WCFServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IInfoUsuarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IInfoUsuarios
    {
        [OperationContract]
        UsuarioInfo CrearUsuarioInfo(UsuarioInfo usuarioInfoACrear);

        [OperationContract]
        UsuarioInfo ObtenerUsuarioInfo(string num_doc);
        [OperationContract]
        List<UsuarioInfo> obtenerListaUsuarioInfo();

    }
}
