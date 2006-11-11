using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Sideris
{
    public interface IHttpWorkerRequestHandler
    {
        void ProcessRequest(HttpWorkerRequest worker_request);
    }
}
