using Microsoft.AspNetCore.Http;

namespace Domain
{
    public class FileUploadModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
        public string Location { get; set; }
        public bool Error { get; set; }

        public FileUploadModel()
        {
            Error = false;
        }

        public void SaveFile(string baseDir)
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

            }
            catch
            {
                this.Error = true;
            }
        }


    }
}