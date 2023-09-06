using Dapper;
using Domain;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Application.DataAccess

{
    internal class SqlConnector : IDataConnection
    {
        private const string db = "filedropper";


        public void PostNewFileToDb(FileModel file)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@name", file.File.FileName);
                p.Add("@type", file.File.ContentType);
                p.Add("@location", file.Location);

                connection.Execute("dbo.spFiles_Insert", p, commandType: CommandType.StoredProcedure);
                file.Id = p.Get<int>("@id");
            }
        }

    }
}
