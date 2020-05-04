using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoDatabase.Models;
using PhotoDownloader.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PhotoDownloader.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Console.WriteLine("Using: " + Startup.DriveLocation);
            DateTime dateTime = DateTime.UtcNow.Date;
            Console.WriteLine("Todays date: " + dateTime.ToString("d"));
            Console.WriteLine("Backup directory: " + Startup.BackupLocation);
            Console.WriteLine();

            // Since we are rendering the sample pictures view inside our index view, we need to run the action method here
            SamplePictures();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult UploadPhotos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhotosPost()
        {
            try
            {

                IFormFileCollection files = Request.Form.Files;
                int fileCount = files.Count;

                if (fileCount > 0)
                {

                    string basePath = GetSavePath(true);

                    for (int i = 0; i < fileCount; i++)
                    {
                        string pathUsing = basePath;

                        Guid test = Guid.NewGuid();

                        pathUsing += Path.DirectorySeparatorChar + test.ToString() + "_" + files[i].FileName;

                        using (var fileStream = new FileStream(pathUsing, FileMode.Create))
                        {
                            await files[i].CopyToAsync(fileStream);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("NO FILES");
                }
                return RedirectToAction("ImageThanks");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewData["message"] = ex.Message;
                ViewData["trace"] = ex.StackTrace;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult ImageThanks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailThanks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmailList(string email)
        {
            Console.WriteLine(email);

            string pathUsing = GetSavePath(false);

            string filePath = pathUsing + Path.DirectorySeparatorChar + "EmailList.txt";

            if (!System.IO.File.Exists(filePath))
            {
                var file = System.IO.File.CreateText(filePath);
                file.Close();
            }

            System.IO.File.AppendAllText(filePath, email + Environment.NewLine);

            return RedirectToAction("EmailThanks");
        }


        private string GetSavePath(Boolean date)
        {
            string DriveLocation = Startup.DriveLocation;
            string BackupLocation = Startup.BackupLocation;

            string pathUsing = "";

            if (Directory.Exists(DriveLocation))
            {
                pathUsing = DriveLocation;
            }
            else if (Directory.Exists(BackupLocation))
            {
                pathUsing = BackupLocation;
            }
            else
            {
                Directory.CreateDirectory(BackupLocation);
                pathUsing = BackupLocation;
            }

            pathUsing += Path.DirectorySeparatorChar + "Photos";

            if (date)
            {
                pathUsing += Path.DirectorySeparatorChar + DateTime.Now.ToString("dd.MM.yyy");
                if (!Directory.Exists(pathUsing))
                {
                    Directory.CreateDirectory(pathUsing);
                }
            }

            return pathUsing;

        }

        public IEnumerable<SamplePicture> GetSamplePictures()
        {
            IList<SamplePicture> answer = new List<SamplePicture>();

            string path = Directory.GetCurrentDirectory();

            string folderPath = path + Path.DirectorySeparatorChar + "wwwroot" + Path.DirectorySeparatorChar + "SamplePictures" + Path.DirectorySeparatorChar;
            string relativePath = "~/SamplePictures/";

            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            bool isRecursive = false;

            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(folderPath, String.Format("*.{0}", filter), searchOption));
            }

            var files = filesFound;

            for (int i = 0; i < filesFound.Count; i++)
            {
                SamplePicture temp = new SamplePicture();
                temp.FileLocation = relativePath + filesFound[i].Substring(folderPath.Length);
                temp.AltText = "Sample picture " + i;
                answer.Add(temp);
            }

            return answer;
        }

        public IActionResult SamplePictures()
        {
            IEnumerable<SamplePicture> samples = GetSamplePictures();

            return View(samples);
        }

        public IActionResult SendEmail()
        {
            return View();
        }

    }
}
