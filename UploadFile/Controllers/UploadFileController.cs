using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFile.Model;
using UploadFile.Service;

namespace UploadFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Playload file) 
        {
            if(file == null)
            {
                return BadRequest("Erro ao tentar carregar o arquivo");
            }

            var service = new UploadFileService();
            var result = await service.SendFile(file);

            if(String.IsNullOrEmpty(result))
            {
                return BadRequest("Erro ao tentar enviar o arquivo");
            }

            return Ok(result);
        }
    }
}
