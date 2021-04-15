#nullable enable
using System;
using System.IO;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Framework.Application
{
    public static class Uploader
    {
        public static string ImageUploader(IFormFile file, string path, string currentImage)
        {
            if (file == null) return "";

            var directoryPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Pictures\\{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            //If currentImage Exists
            ImageRemover(currentImage);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}\\{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}//{fileName}";
        }

        public static void ImageRemover(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName)) return;
            var imagePath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Pictures\\{imageName}";
            if (File.Exists(imagePath)) File.Delete(imagePath);
        }

        public static void DirectoryRemover(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) return;
            var directoryPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Pictures\\{directory}";
            if (Directory.Exists(directoryPath)) Directory.Delete(directoryPath,true);
        }
    }
}
