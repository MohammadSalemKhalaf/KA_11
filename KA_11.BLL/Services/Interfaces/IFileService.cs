using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
