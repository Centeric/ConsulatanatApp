using CaseTracker.Service.DataLogics.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
            if (!new[] { ".pdf", ".doc", ".png", ".jpg", ".docx", ".jpeg" }.Contains(fileExtension))
            {
                throw new InvalidOperationException("File type not allowed.");
            }
            var filename = Path.GetFileName(file.FileName);
            var uniqueFolderName = Guid.NewGuid().ToString();
            var folderPath = Path.Combine(_storagePath, uniqueFolderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, filename);


           await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
        public async Task<Stream> GetFileAsync(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found.");

            return new FileStream(fileName, FileMode.Open, FileAccess.Read);
        }
       
    }
}
