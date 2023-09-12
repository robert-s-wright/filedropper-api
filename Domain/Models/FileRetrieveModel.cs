namespace Domain.Models
{
    public class FileRetrieveModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }



        //return bytes
        public byte[] ReturnByteArray()
        {

            return System.IO.File.ReadAllBytes(this.Location);
        }
        //return memory stream
        public Stream ReturnStream()
        {
            return new MemoryStream(ReturnByteArray());

        }







    }
}
