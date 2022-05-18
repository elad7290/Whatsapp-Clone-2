using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;

namespace Whatsapp_Clone_api.Controllers
{
    [Route("api/invitations")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private UserService _service;

        public InvitationsController(UserService service)
        {
            _service = service;
        }

        //POST: api/invitations
        [HttpPost]
        public ActionResult Invitations(string from, string to, string server)
        {
            if (from == null || to == null || server == null) { return BadRequest(); }
            if (!_service.UserExist(to))
            {
                return NotFound();
            }
            Chat chat = new Chat() { Id = from, Name = from, Server = server };
            _service.AddChat(to, chat);
            return CreatedAtAction(nameof(Invitations), chat);
        }


    }
}
