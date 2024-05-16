using CaseTracker.Service.DataLogics.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.DataLogics.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _storagePath;
        public FileStorageService(IConfiguration configuration)
        {
            _storagePath = configuration.GetValue<string>("FileStorageSettings:StoragePath");
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file.Length == 0)
                throw new InvalidOperationException("File is empty");

            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!new[] { ".pdf", ".doc", ".png", ".jpg", ".docx" }.Contains(fileExtension))
            {
                throw new InvalidOperationException("File type not allowed.");
            }

            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_storagePath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;  
        }
    }
}
