using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;


namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images";

        public static IResult Upload(IFormFile formFile)
        {
            var FileExists = CheckFileExists(formFile);
            if (FileExists.Message!=null)
            {
                return new ErrorResult(FileExists.Message);
            }

            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message!=null)
            {
                return new ErrorResult(typeValid.Message);
            }

            //DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, formFile);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Update(IFormFile formFile ,string imagePath)
        {
            var fileExists = CheckFileExists(formFile);
            if (fileExists.Message!=null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, formFile);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }


        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

       

        private static IResult CheckFileExists(IFormFile formFile)
        {
            if (formFile!=null && formFile.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }


        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/","\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }
    }
}
