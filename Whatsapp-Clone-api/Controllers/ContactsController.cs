using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Services;

namespace Whatsapp_Clone_api.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private UserService _service;


        public ContactsController(UserService service)
        {
            _service = service;
        }

        // GET: api/contacts
        //
        [HttpGet]
        public ActionResult<List<Chat>> GetContacts()
        {
            var username = GetUserId();
            if(username == null) { return BadRequest(); }
            var chats= _service.GetChars(username);
            if(chats == null) { return BadRequest(); }
            return Ok(chats);

        }


        private string? GetUserId()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId"));
            if(token == null)
            {
                return null;
            }
            return token.Value;
        }

        // POST: api/contacts
        [HttpPost]
        public ActionResult Create([Bind("Id,Name,Server,Last,LastDate")] Chat chat)
        {
            return Ok(chat);
        }





    }
}
