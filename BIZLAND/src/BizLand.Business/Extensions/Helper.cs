using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Extensions
{
    public static class Helper
    {
        public static string SaveFile(string path, string folderName, IFormFile file)
        {
            string fileName = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;
            fileName = Guid.NewGuid().ToString() + fileName;

            path = Path.Combine(path, folderName, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;

        }
    }
}
