using BuisinessLogic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Services
{
    public class FileService : IFileService
    {
        private const string imageFolder = "images";
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task DeleteProductImage(string imagePath)
        {
            await Task.Run(() =>
                {
                    string root = _environment.WebRootPath;
                    string imagefullpath = Path.Combine(root, imagePath);
                    if(File.Exists(imagefullpath))
                    {
                        File.Delete(imagefullpath);
                    }
                });
        }

        public async Task<string> UpdateProductImage(string path, IFormFile file)
        {
            string root = _environment.WebRootPath;
            string imagefullpath = Path.Combine(root, file.FileName);
            if (File.Exists(imagefullpath))
            {
                File.Delete(imagefullpath);
            }

            string imagePath = Path.Combine(imageFolder, file.FileName);

            using (FileStream filestream = new FileStream(imagefullpath, FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }

            return imagePath;
        }

        public async Task<string> SaveProductImage(IFormFile file)
        {
            // get path to "wwwroot" for ASP.NET Core
            string root = _environment.WebRootPath;
            string newFileName = Guid.NewGuid().ToString(); // random name of file   picture1
            string extensionFile = Path.GetExtension(file.FileName); //.jpg .png....
            string fullFileName = newFileName + extensionFile;//full name file =>  picture1.png 

            // images/picture1.png    
            string imagePath = Path.Combine(imageFolder, fullFileName);
            //C:\Users\Tetiana\source\repos\ITStepPV114\ShopMVC_part2\ShopMVC\wwwroot\images\picture1.png
            string imageFullPath = Path.Combine(root, imagePath);

            //save file on the folder images

            using (FileStream fileStream = new FileStream(imageFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return imagePath;
        }


    }
}
