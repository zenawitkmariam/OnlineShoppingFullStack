using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCounselling.Context;
using StudentCounselling.Data;
using StudentCounselling.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StudentCounselling.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StudentCouncellingDbContext _dataBase;
        //private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IWebHostEnvironment webHostEnvironment
            , StudentCouncellingDbContext dataBase
            //, IFileUploadService fileUploadService
            )
        {
            this._webHostEnvironment = webHostEnvironment;
            this._dataBase = dataBase;
            //this._fileUploadService = fileUploadService;
        }
        [HttpPut("FileUpload/{userId}")]
        public async Task<string> UploadFiles(string userId, IFormFile objectFile)
        {
            var test = objectFile;
            try
            {
                if (objectFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Upload\\";
                    if (Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(objectFile.FileName);
                    using (FileStream fileStream = System.IO.File.Create(path + imageName))
                    {
                        objectFile.CopyTo(fileStream);
                        fileStream.Flush();
                        var user = this._dataBase.User.Where(t => t.UserId == userId).FirstOrDefault();
                        if (user != null)
                        {
                            user.ImageUrl = "\\Upload\\" + imageName;
                            _dataBase.User.Update(user);
                            var result = _dataBase.SaveChanges();
                            if (result > 0)
                            {
                                return "File Uploaded";
                            }
                            return "Failed to save to the database";
                        }
                        else
                        {
                            return "Invalid user id";
                        }
                    }
                }
                else
                {
                    return "Failed to Upload Image";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("GetFile/{userId}")]
        [HttpGet]
        public async Task<IActionResult> DownloadFile(string userId)
        {

            var user = _dataBase.User.Where(t => t.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                if (user.ImageUrl != null)
                {
                    string path = _webHostEnvironment.WebRootPath + user.ImageUrl;
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(path,FileMode.Open))
                    { 
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    var contentType = "APPLICATIONn/octet-stream";
                    var fileName = Path.GetFileName(path);
                    return File(memory, contentType, fileName);
                }
                return Ok("User has no image");
            }
            return BadRequest(error: "Invalid user id");
        }
    }
}
