using Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Application.DirectoryConfig;

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
            List<FileSaveModel> newFiles = new List<FileSaveModel>();


            foreach (IFormFile f in files)
            {

                FileSaveModel file = new FileSaveModel();
                file.File = f;

                //save to dir
                //SaveFile(file);
                bool exists = file.SaveFile(GetBaseDir());

                //check if exception exists
                if (exists == false)
                {

                    //save dir info to db
                    ConnectionConfig.Connection.PostNewFileToDb(file);
                }

                newFiles.Add(file);
            }

            return Ok(newFiles);

        }




        //POST api/<FileModelController>/Stream
        //[Route("streaming")]
        //public async Task<IActionResult> PostStream()
        //{
        //    return Ok();
        //}

        //TODO add get existing files
        //TODO delete existing files
        //TODO get file by ID > download
    }
}
