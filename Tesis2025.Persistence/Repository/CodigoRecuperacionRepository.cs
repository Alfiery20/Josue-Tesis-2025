using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Tesis2025.Application.Autenticacion.Command.ActualizarClave;
using Tesis2025.Application.Autenticacion.Command.Registrar;
using Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo;
using Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo;
using Tesis2025.Application.Common.Interface;
using Tesis2025.Application.Common.Interface.Repositories;
using Tesis2025.Persistence.Database;

namespace Tesis2025.Persistence.Repository
{
    public class CodigoRecuperacionRepository : ICodigoRecuperacionRepository
    {
        private readonly IDataBase _dataBase;

        public CodigoRecuperacionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }
        
        public async Task<EnviarCodigoCommandDTO> RegistrarCodigo(EnviarCodigoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcodigoValidacion", command.Codigo, DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_RegistrarCodigo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new EnviarCodigoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<ValidarCodigoCommandDTO> ValidarCodigo(ValidarCodigoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcodigoValidacion", command.Codigo, DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ValidarCodigo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var codigo = parameters.Get<string>("codigo");
                var mensaje = parameters.Get<string>("msj");
                return new ValidarCodigoCommandDTO()
                {
                    Codigo = codigo,
                    Mensaje = mensaje
                };
            }
        }

        public async Task<string> ObtenerCorreoUsuario(int idUsuario)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidUsuario", idUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ObtenerCorreoUsuario]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var correoUsuario = parameters.Get<string>("msj");
                return correoUsuario;
            }
        }

    }
}
