using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Whatsapp_Clone_api.Controllers
{
    // [Authorize]
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {


        // GET: api/contacts
        [HttpGet]
        public ActionResult<string> GetContacts()
        {
            return Ok(ClaimTypes.NameIdentifier);
        }
    }
}
