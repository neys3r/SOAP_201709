using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class UsuarioInfoDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=VWallet;Integrated Security=True;";

        public UsuarioInfo CrearUserInfo(UsuarioInfo usuarioInfoACrear)
        {
            UsuarioInfo usuarioInfoCreado = null;
            string sql = "INSERT INTO usuario_info ";
            sql += "values(@nombres, @ape_paterno, @ape_materno, ";
            sql += "@razon_social, @sexo, @direccion, @email, ";
            sql +=" @num_telefono, @num_cuenta, @imp_saldo, @num_doc, @cod_tipodoc)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nombres", usuarioInfoACrear.Nombres));
                    comando.Parameters.Add(new SqlParameter("@ape_paterno", usuarioInfoACrear.ApellidoMat));
                    comando.Parameters.Add(new SqlParameter("@ape_materno", usuarioInfoACrear.ApellidoPat));
                    comando.Parameters.Add(new SqlParameter("@razon_social", usuarioInfoACrear.RazonSocial));
                    comando.Parameters.Add(new SqlParameter("@sexo", usuarioInfoACrear.Sexo));
                    comando.Parameters.Add(new SqlParameter("@direccion", usuarioInfoACrear.Direccion));
                    comando.Parameters.Add(new SqlParameter("@email", usuarioInfoACrear.Email));
                    comando.Parameters.Add(new SqlParameter("@num_telefono", usuarioInfoACrear.Telefono));
                    comando.Parameters.Add(new SqlParameter("@num_cuenta", usuarioInfoACrear.Cuenta));
                    comando.Parameters.Add(new SqlParameter("@imp_saldo", usuarioInfoACrear.Saldo));
                    comando.Parameters.Add(new SqlParameter("@num_doc", usuarioInfoACrear.NumeroDoc));
                    comando.Parameters.Add(new SqlParameter("@cod_tipodoc", usuarioInfoACrear.TipoDoc));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioInfoCreado = ObtenerUserInfo(usuarioInfoACrear.NumeroDoc);
            return usuarioInfoCreado;
        }

        public UsuarioInfo ObtenerUserInfo(string num_doc)
        {

            UsuarioInfo usuarioInfoEncontrado = null;
            string sql = "SELECT * FROM usuario_info WHERE num_doc=@num_doc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_doc", num_doc));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioInfoEncontrado = new UsuarioInfo()
                            {
                                Nombres = (string)resultado["nombres"],
                                ApellidoMat = (string)resultado["ape_paterno"],
                                ApellidoPat = (string)resultado["ape_materno"],
                                RazonSocial = (string)resultado["razon_social"],
                                Sexo = (string)resultado["sexo"],
                                Direccion = (string)resultado["direccion"],
                                Email = (string)resultado["email"],
                                Telefono = (string)resultado["num_telefono"],
                                Cuenta = (string)resultado["num_cuenta"],
                                Saldo = (decimal)resultado["imp_saldo"],
                                NumeroDoc = (string)resultado["num_doc"],
                                TipoDoc = (string)resultado["cod_tipodoc"],
                            };
                        }
                    }
                }
            }
            return usuarioInfoEncontrado;
        }


        public List<UsuarioInfo> obtenerListaUsuarioInfo()
        {
            List<UsuarioInfo> lista = new List<UsuarioInfo>();

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("sp_listar_personas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new UsuarioInfo()
                            {
                                Nombres = (string)(dr["nombres"] == null ? "" : dr["nombres"]),
                                ApellidoMat= (string)(dr["ape_materno"] == null ? "" : dr["ape_materno"]),
                                ApellidoPat = (string)(dr["ape_paterno"] == null ? "" : dr["ape_paterno"]),
                                Email = (string)(dr["email"] == null ? "" : dr["email"]),
                                Direccion = (string)(dr["direccion"] == null ? "" : dr["direccion"]),
                                RazonSocial  = (string)(dr["razon_social"] == null ? "" : dr["razon_social"]),
                                Sexo = (string)(dr["sexo"] == null ? "" : dr["sexo"]),
                                Telefono = (string)(dr["num_telefono"] == null ? "" : dr["num_telefono"]),
                                Cuenta = (string)(dr["num_cuenta"] == null ? "" : dr["num_cuenta"]),
                                Saldo = (decimal)dr["imp_saldo"],
                                NumeroDoc =(string)dr["num_doc"],
                                tipoDocumento = (string)dr["nom_tipodoc"],
                                estado = (bool)dr["estado"]
                            });
                        }
                    }
                }
            }

            return lista;

        }

    }
}