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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarios
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Usuario CrearUsuario(Usuario usuarioACrear);

        [OperationContract]
        Usuario ObtenerUsuario(string num_doc);

        [OperationContract]
        UsuarioInfo accesoAccountLogin(Usuario usuario);


        //[OperationContract]
        //Usuario ModificarUsuario(Usuario usuarioAModificar);
        //[OperationContract]
        //void EliminarUsuario(int idusuario);

        //[OperationContract]
        //List<Usuario> ListarUsuarioes();

    }
}
