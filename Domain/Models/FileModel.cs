using Microsoft.AspNetCore.Http;

namespace Domain
{
    public class FileModel
    {
        public int? Id { get; set; }
        public IFormFile File { get; set; }
        public string Location { get; set; }
        public bool Error { get; set; }

        public FileModel()
        {
            Error = false;
        }
    }
}