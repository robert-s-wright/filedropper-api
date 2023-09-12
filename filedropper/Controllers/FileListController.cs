using Application;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileListController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetAllFileNames()
        {

            return Ok(ConnectionConfig.Connection.GetAllFilesWExt());
        }
    }
}
