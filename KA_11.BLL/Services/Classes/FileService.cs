using KA_11.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class FileService : IFileService
    {
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() +Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }
            throw new Exception("File is null or empty"); 
        }
    }
}
