using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Net.Http.Headers;
using System.IO;

namespace FoosballApi.Controllers
{
    public class VideoController : ApiController
    {
        [HttpPost]
        [Route("api/Upload/")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new CustomMultipartFormDataStreamProvider(HostingEnvironment.MapPath("~/App_Data"));

            List<string> files = new List<string>();
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    files.Add(Path.GetFileName(file.LocalFileName));
                }

                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

         }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }
}
