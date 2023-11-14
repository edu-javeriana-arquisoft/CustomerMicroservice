using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Data;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {

        private readonly PreferenceService _preferenceService;

        public PreferencesController(PreferenceService preferenceService)
        {
            _preferenceService = preferenceService;
        }



    }
}
