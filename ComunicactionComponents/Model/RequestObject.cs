using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComuncactionComponents.Model.Config
{
    public class RequestObject
    {
        public HttpStatusCode Status { get; set; }
        public string ObjectRequest { get; set; }
        public string Component { get; set; }
        public string User { get; set; }
        public bool IsValid { get; set; }
    }
}
