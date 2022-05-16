using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Whatsapp_Clone_api.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private User _user;

        public ContactsController()
        {
            if (_user == null)
            {
                _user = new User() { Username = "Lion", Nickname = "lio", Password = "123456789L!" };
            }
        }

        // GET: api/contacts
        //
        [HttpGet]
        public ActionResult<List<Chat>> GetContacts()
        {
            if (_user == null)
            {
                return BadRequest(); // NotFound??
            }
            return Ok(_user.ActiveChats);

        }
        //POST: api/contacts
        [HttpPost]
        public IActionResult AddContact([Bind("Id,Name,Server")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                _user.ActiveChats.Add(chat);
                return CreatedAtAction(nameof(GetContacts), chat);
            }
            return BadRequest();
            
        }


    }
}
