using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Client : Controller
    {
        ErrorBO _Access = new ErrorBO();
        ClientWalletRechargeBL _ClientRechargeBL = new ClientWalletRechargeBL();

        private readonly IHostingEnvironment _hostingEnvironment;

        public Client(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

  
    }
}
