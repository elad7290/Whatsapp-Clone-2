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
        public ActionResult Invitations([Bind("from, to, server")] Invitation invite)
        {
            if (invite.from == null || invite.to == null || invite.server == null) { return BadRequest(); }
            if (!_service.UserExist(invite.to))
            {
                return NotFound();
            }
            Chat chat = new Chat() { Id = invite.from, Name = invite.from, Server = invite.server };
            _service.AddChat(invite.to, chat);
            return CreatedAtAction(nameof(Invitations), chat);
        }


    }
}
