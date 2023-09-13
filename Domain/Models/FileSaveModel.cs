using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class FileSaveModel
    {
        public int? Id { get; set; }
        public IFormFile File { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }


        public bool SaveFile(string baseDir)
        {
            //string baseDir = GetBaseDir();

            string path = baseDir + this.File.FileName;

            Directory.CreateDirectory(baseDir);

            try
            {
                using (Stream fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    this.File.CopyToAsync(fileStream);

                }
                this.Location = path;
                return false;

            }
            catch
            {
                return true;
            }
        }

        public FileListModel CastToListModel()
        {
            return new FileListModel
            {
                Id = this.Id,
                Name = this.File.FileName,
                Type = this.File.ContentType.ToString()
            };
        }

    }
}
