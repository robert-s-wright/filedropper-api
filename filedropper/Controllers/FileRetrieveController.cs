using Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileRetrieveController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFile(int id)
        {
            FileRetrieveModel file = ConnectionConfig.Connection.GetFileById(id);

            var f = File(file.ReturnByteArray(), file.Type, file.Name);

            return f;
        }
    }
}
