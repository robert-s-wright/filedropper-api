using Domain;
using static Application.DirectoryConfig;

namespace Application
{
    public class Methods
    {
        public static void SaveFile(FileModel file)
        {
            string dir = GetBaseDir();

            string path = dir + file.File.FileName;

            Directory.CreateDirectory(dir);

            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                file.File.CopyToAsync(fileStream);
            }
            file.Location = path;
        }

    }
}
