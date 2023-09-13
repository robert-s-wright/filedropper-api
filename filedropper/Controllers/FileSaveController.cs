using Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Application.DirectoryConfig;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace filedropper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSaveController : ControllerBase
    {
        // POST api/<FileModelController>
        [HttpPost]
        public ActionResult PostNewFile(IFormFileCollection files)
        {
            List<FileListModel> newFiles = new();


            foreach (IFormFile f in files)
            {

                FileSaveModel file = new() { File = f };

                //save to dir
                bool exists = file.SaveFile(GetBaseDir());

                //check if exception exists
                if (exists == false)
                {
                    //save dir info to db
                    newFiles.Add(ConnectionConfig.Connection.PostNewFileToDb(file));

                }
                else
                {
                    newFiles.Add(file.CastToListModel());
                }

            }
            return Ok(newFiles);

        }

        //TODO delete existing files

    }
}
