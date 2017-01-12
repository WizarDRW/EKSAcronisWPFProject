using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.Classes
{
    class AuthorityReview
    {
        public string AutUserName { get; set; }
        public string ReturnAutDatabase { get; set; }
        public string AutisNull { get; set; }
        public string Admin { get; set; }
        Authority A = new Authority();

        public string ReturnAut()
        {
            ReturnAutDatabase = A.AutMethod(AutUserName);
            if (ReturnAutDatabase == null || ReturnAutDatabase == "")
                return AutisNull = "0";
            else
                return ReturnAutDatabase;


        }
    }
}
