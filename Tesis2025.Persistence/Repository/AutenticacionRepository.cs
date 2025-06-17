using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Tesis2025.Application.Autenticacion.Command.ActualizarClave;
using Tesis2025.Application.Autenticacion.Command.IniciarSesion;
using Tesis2025.Application.Autenticacion.Command.Registrar;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Persistence.Database;

namespace Tesis2025.Persistence.Repository
{
    public class AutenticacionRepository : IAutenticacionRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography _cryptography;

        public AutenticacionRepository(IServiceProvider serviceProvider, ICryptography cryptography)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this._cryptography = cryptography;
        }

        public async Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pemail", command.Correo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pclave", this._cryptography.Encrypt(command.Clave), DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_IniciarSesion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    IniciarSesionCommandDTO response = new();
                    while (reader.Read())
                    {
                        response = new IniciarSesionCommandDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Apellido = Convert.IsDBNull(reader["APELLIDO"]) ? "" : reader["APELLIDO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Direccion = Convert.IsDBNull(reader["DIRECCION"]) ? "" : reader["DIRECCION"].ToString(),
                            Distrito = Convert.IsDBNull(reader["DISTRITO"]) ? "" : reader["DISTRITO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString()
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<RegistrarCommandDTO> Registrar(RegistrarCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidos", command.Apellidos, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnumeroDocumento", command.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdireccion", command.Direccion, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdistrito", command.Distrito, DbType.String, ParameterDirection.Input);

                parameters.Add("@@pcorreo", command.Correo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pclave", this._cryptography.Encrypt(command.Clave), DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarUsuario]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new RegistrarCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<ActualizarClaveCommandDTO> ActualizarClave(ActualizarClaveCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pclaveNueva", this._cryptography.Encrypt(command.Clave), DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ActualizarContrasenia]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new ActualizarClaveCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }
    }
}
