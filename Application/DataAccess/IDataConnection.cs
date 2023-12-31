﻿using Domain.Models;

namespace Application.DataAccess
{
    public interface IDataConnection
    {
        FileListModel PostNewFileToDb(FileSaveModel file);

        List<FileRetrieveModel> GetAllFilesFromDb();

        FileRetrieveModel GetFileById(int fileId);

        //file list methods
        List<FileListModel> GetAllFilesWExt();
    }
}
