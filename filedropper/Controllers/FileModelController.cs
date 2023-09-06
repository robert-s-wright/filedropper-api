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
        public ActionResult Post(IFormFileCollection files)
        {
            List<FileModel> newFiles = new List<FileModel>();
            foreach (IFormFile f in files)
            {
                FileModel file = new FileModel();
                file.File = f;

                //save to dir
                SaveFile(file);

                //save dir info to db
                ConnectionConfig.Connection.PostNewFileToDb(file);
                newFiles.Add(file);
            }

            return Ok(newFiles);
        }

        //TODO add get existing files
        //TODO delete existing files
        //TODO get file by ID > download
    }
}
