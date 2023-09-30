using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComuncactionComponents.Model.Config
{
    public class DataResponse<T>
    {
        public DataResponse()
        {
            Head = new HeadResponse();
            Body = new BodyResponse<T>();
        }
        public HeadResponse Head { get; set; }
        public BodyResponse<T> Body { get; set; }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.NoContent;
    }

    public class DataResponse
    {
        public DataResponse()
        {
            Head = new HeadResponse();
            Body = new BodyResponse<string>();
        }
        public HeadResponse Head { get; set; }
        public BodyResponse<string> Body { get; set; }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.NoContent;
    }
    public class HeadResponse
    {
        public HeadResponse()
        {
            error = new Error();
        }
        public string Status { get; set; }
        public object TimeControl { get; set; }
        public Error error { get; set; }
        public object StackError { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class BodyResponse<T>
    {
        public string Response { get; set; }
        public T Result { get; set; }
    }
}
