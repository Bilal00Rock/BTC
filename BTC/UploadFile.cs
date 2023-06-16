using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BTC
{
    public class UploadFile
    {

        private readonly IWebHostEnvironment _webhostenvironment;
        public UploadFile(IWebHostEnvironment webHostEnvitoment)
        {
            _webhostenvironment = webHostEnvitoment;
        }
        public string Upload(IFormFile file)
        {
            if(file == null) return null;
            var path = _webhostenvironment.WebRootPath + "\\image\\Product\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }

    }
}
