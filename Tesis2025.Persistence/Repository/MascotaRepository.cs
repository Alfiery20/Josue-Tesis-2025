using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Application.Mascota.Command.RegistrarMascota;
using Tesis2025.Application.Mascota.Command.RegistrarMascotaPerdida;
using Tesis2025.Application.Mascota.Query.ObtenerMascota;
using Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida;
using Tesis2025.Persistence.Database;

namespace Tesis2025.Persistence.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly IDataBase _dataBase;

        public MascotaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<RegistrarMascotaCommandDTO> RegistrarMascota(RegistrarMascotaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pfechaNacimiento", command.FechaNacimiento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pespecie", command.Especie, DbType.String, ParameterDirection.Input);
                parameters.Add("@pgenero", command.Genero, DbType.String, ParameterDirection.Input);
                parameters.Add("@prazaCanina", command.Raza, DbType.String, ParameterDirection.Input);
                parameters.Add("@ptamanio", command.Tamanio, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcaracter", command.Caracter, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcolor", command.Color, DbType.String, ParameterDirection.Input);
                parameters.Add("@ppelaje", command.Pelaje, DbType.String, ParameterDirection.Input);
                parameters.Add("@pesterelizado", command.Esterelizado, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdistritoResidente", command.Distrito, DbType.String, ParameterDirection.Input);
                parameters.Add("@pmodoObtencion", command.ModoObtencion, DbType.String, ParameterDirection.Input);
                parameters.Add("@prazonTenencia", command.RazonTenencia, DbType.String, ParameterDirection.Input);
                parameters.Add("@pfoto", command.Foto, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarMascota]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new RegistrarMascotaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<RegistrarMascotaPerdidaCommandDTO> RegistrarMascotaPerdida(RegistrarMascotaPerdidaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pfechaPerdida", command.FechaPerdida, DbType.String, ParameterDirection.Input);
                parameters.Add("@plugarPerdida", command.LugarPerdida, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcomentario", command.Comentario, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidMascota", command.IdMascota, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarMascotaPerdida]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new RegistrarMascotaPerdidaCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<IEnumerable<ObtenerMascotaQueryDTO>> ObtenerMascotas(ObtenerMascotaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdUsuario", query.IdUsuario, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMascota]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMascotaQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMascotaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            FechaNacimiento = Convert.IsDBNull(reader["FECHA_NACIMIENTO"]) ? "" : reader["FECHA_NACIMIENTO"].ToString(),
                            Especie = Convert.IsDBNull(reader["ESPECIE"]) ? "" : reader["ESPECIE"].ToString(),
                            Genero = Convert.IsDBNull(reader["GENERO"]) ? "" : reader["GENERO"].ToString(),
                            Raza = Convert.IsDBNull(reader["RAZA"]) ? "" : reader["RAZA"].ToString(),
                            Tamanio = Convert.IsDBNull(reader["TAMANIO"]) ? "" : reader["TAMANIO"].ToString(),
                            Caracter = Convert.IsDBNull(reader["CARACTER"]) ? "" : reader["CARACTER"].ToString(),
                            Color = Convert.IsDBNull(reader["COLOR"]) ? "" : reader["COLOR"].ToString(),
                            Pelaje = Convert.IsDBNull(reader["PELAJE"]) ? "" : reader["PELAJE"].ToString(),
                            Esterelizado = Convert.IsDBNull(reader["ESTERELIZADO"]) ? "" : reader["ESTERELIZADO"].ToString(),
                            Distrito = Convert.IsDBNull(reader["DISTRITO"]) ? "" : reader["DISTRITO"].ToString(),
                            Obtencion = Convert.IsDBNull(reader["OBTENCION"]) ? "" : reader["OBTENCION"].ToString(),
                            Tenencia = Convert.IsDBNull(reader["TENENCIA"]) ? "" : reader["TENENCIA"].ToString(),
                            Foto = Convert.IsDBNull(reader["FOTO"]) ? "" : reader["FOTO"].ToString(),
                            IdUsuario = Convert.IsDBNull(reader["ID_USUARIO"]) ? 0 : Convert.ToInt32(reader["ID_USUARIO"].ToString()),
                            NombreUsuario = Convert.IsDBNull(reader["NOMBRE_USUARIO"]) ? "" : reader["NOMBRE_USUARIO"].ToString(),
                            ApellidoUsuario = Convert.IsDBNull(reader["APELLIDO_USUARIO"]) ? "" : reader["APELLIDO_USUARIO"].ToString()

                        });
                    }
                    return response;
                }
            }
        }

        public async Task<IEnumerable<ObtenerMascotaPerdidaQueryDTO>> ObtenerMascotasPerdidas(ObtenerMascotaPerdidaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdUsuario", query.IdUsuario, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMascotaPerdida]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMascotaPerdidaQueryDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMascotaPerdidaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            FechaNacimiento = Convert.IsDBNull(reader["FECHA_NACIMIENTO"]) ? "" : reader["FECHA_NACIMIENTO"].ToString(),
                            Especie = Convert.IsDBNull(reader["ESPECIE"]) ? "" : reader["ESPECIE"].ToString(),
                            Genero = Convert.IsDBNull(reader["GENERO"]) ? "" : reader["GENERO"].ToString(),
                            Raza = Convert.IsDBNull(reader["RAZA"]) ? "" : reader["RAZA"].ToString(),
                            Tamanio = Convert.IsDBNull(reader["TAMANIO"]) ? "" : reader["TAMANIO"].ToString(),
                            Caracter = Convert.IsDBNull(reader["CARACTER"]) ? "" : reader["CARACTER"].ToString(),
                            Color = Convert.IsDBNull(reader["COLOR"]) ? "" : reader["COLOR"].ToString(),
                            Pelaje = Convert.IsDBNull(reader["PELAJE"]) ? "" : reader["PELAJE"].ToString(),
                            Esterelizado = Convert.IsDBNull(reader["ESTERELIZADO"]) ? "" : reader["ESTERELIZADO"].ToString(),
                            Distrito = Convert.IsDBNull(reader["DISTRITO"]) ? "" : reader["DISTRITO"].ToString(),
                            Obtencion = Convert.IsDBNull(reader["OBTENCION"]) ? "" : reader["OBTENCION"].ToString(),
                            Tenencia = Convert.IsDBNull(reader["TENENCIA"]) ? "" : reader["TENENCIA"].ToString(),
                            Foto = Convert.IsDBNull(reader["FOTO"]) ? "" : reader["FOTO"].ToString(),
                            IdUsuario = Convert.IsDBNull(reader["ID_USUARIO"]) ? 0 : Convert.ToInt32(reader["ID_USUARIO"].ToString()),
                            NombreUsuario = Convert.IsDBNull(reader["NOMBRE_USUARIO"]) ? "" : reader["NOMBRE_USUARIO"].ToString(),
                            ApellidoUsuario = Convert.IsDBNull(reader["APELLIDO_USUARIO"]) ? "" : reader["APELLIDO_USUARIO"].ToString(),
                            FechaPerdida = Convert.IsDBNull(reader["FECHA_PERDIDA"]) ? "" : reader["FECHA_PERDIDA"].ToString(),
                            LugarPerdida = Convert.IsDBNull(reader["LUGAR_PERDIDA"]) ? "" : reader["LUGAR_PERDIDA"].ToString(),
                            Comentario = Convert.IsDBNull(reader["COMENTARIO"]) ? "" : reader["COMENTARIO"].ToString()

                        });
                    }
                    return response;
                }
            }
        }
    }
}
