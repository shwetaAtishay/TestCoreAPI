using BL;
using BO;
using BO.Models;
using DL;
using Microsoft.AspNetCore.Mvc;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProofOfDocController : Controller
    {
        ProofOfDocumentBL objProofOfDocBL = new ProofOfDocumentBL();
        [HttpPost]
        [Route("DocumentDetailSave")]
        public ErrorBO DocumentDetailSave(ProofOfDocumentBO obj)
        {

            return objProofOfDocBL.DocumentDetail(obj);

        }
    }
}