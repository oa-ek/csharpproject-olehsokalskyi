using Application.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Untils
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment env)
        {
            environment = env;
        }
        public bool DeleteImage(string imageFileName, string directory)
        {
            try
            {
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "img", directory, imageFileName);
                if (File.Exists(dir))
                {
                    File.Delete(dir);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the file from server", ex);
            }
        }

        public string SaveImage(string base64, string directory)
        {
            var base64Data = base64.StartsWith("data:image/png;base64,") ?
                base64.Substring("data:image/png;base64,".Length) : base64;

            var bytes = Convert.FromBase64String(base64Data);
            try
            {
                using var stream = new MemoryStream(bytes);
                var image = System.Drawing.Image.FromStream(stream);
                var img = new Bitmap(image);
                string randomFilename = Guid.NewGuid() + ".jpeg";
                var dir = Path.Combine(Directory.GetCurrentDirectory(), "img", directory);

                // Create the directory if it does not exist
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var filePath = Path.Combine(dir, randomFilename);
                img.Save(filePath, ImageFormat.Jpeg);
                return Path.Combine("img", directory, randomFilename);
            }
            catch
            {
                throw;
            }
        }

        public string SaveIFormFile(IFormFile file, string directory)
        {
            try
            {
                // Generate a unique filename
                string randomFilename = Path.GetRandomFileName() + Guid.NewGuid() + Path.GetExtension(file.FileName);
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "img", directory);

                // Create the directory if it does not exist
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string filePath = Path.Combine(dir, randomFilename);

                // Save the file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Path.Combine("img", directory, randomFilename);
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while saving the file", ex);
            }
        }
    }
}
