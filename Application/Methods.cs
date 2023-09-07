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

            try
            {
                using (Stream fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    file.File.CopyToAsync(fileStream);

                }
                file.Location = path;

            }
            catch
            {
                file.Error = true;
            }
        }

    }
}
