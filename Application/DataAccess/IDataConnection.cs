using Domain;

namespace Application.DataAccess
{
    public interface IDataConnection
    {
        void PostNewFileToDb(FileModel file);
    }
}
