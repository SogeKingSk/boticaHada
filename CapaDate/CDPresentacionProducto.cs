using CapaEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDate
{
    public class CDPresentacionProducto
    {
        public List<PresentacionProducto> Listar()
        {
            List<PresentacionProducto> lista = new List<PresentacionProducto>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select pp.IdPresentacionProducto,pp.IdProducto,p.Codigo,p.Nombre,pp.TipoPresentacion,pp.Cantidad,pp.PrecioCompra,pp.PrecioVenta,pp.Stock from PRESENTACION_PRODUCTO pp\r\n");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = pp.IdProducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new PresentacionProducto()
                            {
                                IdPresentacionProducto = Convert.ToInt32(dr["IdPresentacionProducto"]),
                                oProducto = new Producto() 
                                { 
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                },
                                
                                TipoPresentacion = dr["TipoPresentacion"].ToString(),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Stock = Convert.ToInt32(dr["Stock"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<PresentacionProducto>();
                }

                return lista;
            }
        }

        public int Registrar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPRESENTACIONPRODUCTO", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", oPresentacionProducto.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("TipoPresentacion", oPresentacionProducto.TipoPresentacion);
                    cmd.Parameters.AddWithValue("Cantidad", oPresentacionProducto.Cantidad);
                    cmd.Parameters.AddWithValue("Stock", oPresentacionProducto.Stock);
                    cmd.Parameters.AddWithValue("PrecioCompra", oPresentacionProducto.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", oPresentacionProducto.PrecioVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                Mensaje = ex.Message;

            }

            return idProductoGenerado;

        }

        public bool Editar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARPRESENTACION", oconexion);
                    cmd.Parameters.AddWithValue("IdPresentacionProducto", oPresentacionProducto.IdPresentacionProducto);
                    cmd.Parameters.AddWithValue("IdProducto", oPresentacionProducto.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("TipoPresentacion", oPresentacionProducto.TipoPresentacion);
                    cmd.Parameters.AddWithValue("Stock", oPresentacionProducto.Stock);
                    cmd.Parameters.AddWithValue("Cantidad", oPresentacionProducto.Cantidad);
                    cmd.Parameters.AddWithValue("PrecioCompra", oPresentacionProducto.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", oPresentacionProducto.PrecioVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }

            return respuesta;

        }


        public bool Eliminar(PresentacionProducto oPresentacionProducto, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPRESENTACION", oconexion);
                    cmd.Parameters.AddWithValue("IdPresentacionProducto", oPresentacionProducto.IdPresentacionProducto);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;

            }

            return respuesta;

        }

        public Producto BuscarProductoPorCodigo(string codigo)
        {
            Producto producto = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTO", oconexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            producto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Nombre = dr["Nombre"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return producto;
        }

        public PresentacionProducto BuscarProductoPorCodigoQR(string codigo)
        {
            PresentacionProducto pproducto = null;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_BUSCAR_PRODUCTO_UNIDAD", oconexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pproducto = new PresentacionProducto()
                            {
                                oProducto = new Producto
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                },
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                

                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return pproducto;
        }

    }
}
