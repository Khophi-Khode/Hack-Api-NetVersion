using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace HackApi.ApiController
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        public MainController() { }

        [HttpPost("upload/{image}")]
        public ImageUploadResult PostImageToServer(string image)
        {
            var cloudinary = GetCloudinaryAccountInfo();

            var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images/" + image);
            var tranform = new Transformation().Crop("scale").Width(200).Height(200);
            var eagerTransform = new List<Transformation>() {
                new Transformation().Width(200).Height(200).Crop("thumb").Gravity("face").Radius(20).Effect("sepia"),
                new Transformation().Width(100).Height(150).Crop("fit")
            };
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imagePath),
                PublicId="cy_id",
                Transformation = tranform,
                EagerTransforms = eagerTransform,
                Tags= "Khophi_"+image,
                Folder="/web",
                Overwrite=true,
                Colors=true
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            return uploadResult;
        }
        

        public Cloudinary GetCloudinaryAccountInfo()
        {
            var account = new Account
            {
                Cloud = "wendolin",
                ApiKey = "447918465166282",
                ApiSecret = "RCoyVQF9Gbxc6oNCNDfoNTK9-Nw"
            };
            var cloudinary = new Cloudinary(account);
            return cloudinary;
        }

    }
}
