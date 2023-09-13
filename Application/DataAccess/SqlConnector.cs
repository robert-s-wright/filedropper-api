using Dapper;
using Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Application.DataAccess

{
    internal class SqlConnector : IDataConnection
    {
        public FileListModel PostNewFileToDb(FileSaveModel file)
        {
            FileListModel newFile = new();
            using (IDbConnection connection = new SqlConnection(ConnectionConfig.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@name", file.File.FileName);
                p.Add("@type", file.File.ContentType);
                p.Add("@location", file.Location);

                connection.Execute("dbo.spFiles_Insert", p, commandType: CommandType.StoredProcedure);
                file.Id = p.Get<int>("@id");

                newFile = file.CastToListModel();
            }
            return newFile;
        }

        public List<FileRetrieveModel> GetAllFilesFromDb()
        {
            List<FileRetrieveModel> files = new List<FileRetrieveModel>();
            using (IDbConnection connection = new SqlConnection(ConnectionConfig.CnnString()))
            {
                files = connection.Query<FileRetrieveModel>("dbo.spFiles_GetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            return files;
        }

        public FileRetrieveModel GetFileById(int fileId)
        {
            FileRetrieveModel file = new FileRetrieveModel();
            using (IDbConnection connection = new SqlConnection(ConnectionConfig.CnnString()))
            {
                var p = new DynamicParameters();
                p.Add("@id", fileId);

                file = connection.Query<FileRetrieveModel>("dbo.spFiles_GetById", p, commandType: CommandType.StoredProcedure).First();
            }
            return file;
        }

        public List<FileListModel> GetAllFilesWExt()
        {
            List<FileListModel> files;
            using (IDbConnection connection = new SqlConnection(ConnectionConfig.CnnString()))
            {
                files = connection.Query<FileListModel>("dbo.spFiles_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return files;
        }
    }
}
