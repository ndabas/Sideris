#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Hosting;

#endregion

namespace Sideris.SiderisServer
{
    public interface IRequestProcessor
    {
        void ProcessRequest(RequestProxy proxy);
    }

    public class RequestProxy : MarshalByRefObject
    {
        private HttpWorkerRequest request;
        public HttpWorkerRequest HttpWorkerRequest
        {
            get { return request; }
        }

        public RequestProxy(HttpWorkerRequest wr)
        {
            request = wr;
        }
    }
}
