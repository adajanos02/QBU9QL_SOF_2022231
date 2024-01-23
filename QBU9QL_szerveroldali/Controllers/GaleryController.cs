using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;
using System.Diagnostics;

namespace QBU9QL_szerveroldali.Controllers
{
    public class GaleryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _ctx;

        BlobServiceClient serviceClient;
        BlobContainerClient containerClient;

        public GaleryController(ILogger<HomeController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
            this.serviceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=oenikajf;AccountKey=WoP60TInx7emBoLLRksZrpIT67tnf9S6kNWYAAirri9nik1p0vwXSblny+GF1/CVIOwtv7VIp/lG+ASt7BMMSA==;EndpointSuffix=core.windows.net");
            this.containerClient = serviceClient.GetBlobContainerClient("photo");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AddPhoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto([FromForm] Galery p, [FromForm] IFormFile photoUpload)
        {
            using (var stream = photoUpload.OpenReadStream())
            {
                BlobClient blobClient = containerClient.GetBlobClient(p.Id + "_" + p.Name.Replace(" ", "").ToLower());
                using (var uploadFileStream = photoUpload.OpenReadStream())
                {
                    await blobClient.UploadAsync(uploadFileStream, true);
                }
                blobClient.SetAccessTier(AccessTier.Cool);
                p.PhotoUrl = blobClient.Uri.AbsoluteUri;
            }
                
            var old = _ctx.Galery.FirstOrDefault(t => t.Name == p.Name && t.PhotoUrl == p.PhotoUrl);
            if (old == null)
            {
                _ctx.Galery.Add(p);
                _ctx.SaveChanges();
            }
            

            return RedirectToAction(nameof(ListPhoto));
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(string uid)
        {
            var item = _ctx.Galery.FirstOrDefault(t => t.Id == uid);
            if (item != null)
            {
                _ctx.Galery.Remove(item);
                _ctx.SaveChanges();
            }
            return RedirectToAction(nameof(ListPhoto));
        }
        public IActionResult ListPhoto()
        {
            return View(_ctx.Galery);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    //public async Task<IActionResult> GetImage(string id)
    //{

    //    var picture = _ctx.Galery.Where(t=> t.Id == id).FirstOrDefault();
    //    return new FileContentResult(picture.PhotoData, picture.ContentType);
    //}
}

