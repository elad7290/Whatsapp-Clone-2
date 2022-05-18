using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace Whatsapp_Clone_api.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    public class TransferController : ControllerBase
    {

        private UserService _service;

        public TransferController(UserService service)
        {
            _service = service;
        }

        //POST: api/transfer
        [HttpPost]
        public ActionResult Transfer(string from, string to, string content)
        {
            if(from == null || to == null || content == null) { return BadRequest(); }
            if (!_service.UserExist(to))
            {
                return NotFound();
            }           
            if (_service.ChatExist(to, from))
            {
                Message message = new Message() { Content = content, Created = DateTime.Now.ToString(), Sent = false };
                _service.AddMessage(to, from, message);
                return CreatedAtAction(nameof(Transfer), message);
            }
            return BadRequest();
        }
    }
}
