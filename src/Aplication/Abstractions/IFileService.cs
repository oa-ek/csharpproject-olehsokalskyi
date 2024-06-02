using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IFileService
    {
        public string SaveImage(string imageFile, string directory);
        public string SaveIFormFile(IFormFile imageFile, string directory);
        public bool DeleteImage(string imageFileName, string directory);
    }
}
