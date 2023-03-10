using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class ProofOfDocumentBL
    {
        ProofOfDocumentDL objProofOfDocDL = new ProofOfDocumentDL();

        public ErrorBO DocumentDetail(ProofOfDocumentBO obj)
        {
            return objProofOfDocDL.DocumentDetail(obj);
        }


    }
}
