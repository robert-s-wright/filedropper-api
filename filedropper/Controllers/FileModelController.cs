using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using static Application.Methods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace filedropper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileModelController : ControllerBase
    {

        // POST api/<FileModelController>
        [HttpPost]
        public ActionResult PostNewFile(IFormFileCollection files)
        {
            List<FileModel> responseFiles = new List<FileModel>();

            foreach (IFormFile f in files)
            {

                FileModel file = new FileModel();
                file.File = f;

                //save to dir
                SaveFile(file);

                //check if exception exists
                if (file.Error == false)
                {

                    //save dir info to db
                    ConnectionConfig.Connection.PostNewFileToDb(file);
                }

                responseFiles.Add(file);
            }


            return Ok(responseFiles);



        }

        //TODO add get existing files
        //TODO delete existing files
        //TODO get file by ID > download
    }
}
