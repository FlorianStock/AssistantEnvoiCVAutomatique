using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_d_envoi_de_cv
{
    public class Profile
    {
        public string profilName = "";
        public string mailContent = "";
        public List<String> filesPath = new List<string>();
        public bool live = true;
        
        public string subject = "";
    }

}
