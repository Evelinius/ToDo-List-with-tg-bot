using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly BotUserRegistrationHelper _registrationHelper;

        public SettingsController(BotUserRegistrationHelper registrationHelper)
        {
            _registrationHelper = registrationHelper;
        }

        [HttpGet("~/settings")]
        public IActionResult RegisterBotUser()
        {
            var guid = _registrationHelper.StartRegistration(1);

            return Ok(guid);
        }
    }
}
