using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.Service.Common
{
    public class File
    {
        public string SaveCertificationToStorage(int userId, byte[] fileContent, string? fileExtension, string? filename_)
        {
       
            string Create_dir_name_ = userId + "_" + filename_;
            string newDirectoryName = Create_dir_name_;
            string newDirectoryPath = Path.Combine("wwwroot", "uploads/files", newDirectoryName);



            if (!Directory.Exists(newDirectoryPath))
            {
                Directory.CreateDirectory(newDirectoryPath);
            }

            string fileName = filename_ + fileExtension;
            string filePath = Path.Combine(newDirectoryPath, fileName);

            // Check if the file already exists in the directory
            if (System.IO.File.Exists(filePath))
            {

            }

            System.IO.File.WriteAllBytes(filePath, fileContent);

            return "/uploads/files/" + newDirectoryName;


        }
    }
}
