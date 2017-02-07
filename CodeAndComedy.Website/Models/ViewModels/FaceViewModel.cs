using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Face.Contract;

namespace CodeAndComedy.Website.Models.ViewModels
{
    public class FaceViewModel
    {
        public string ImageUrl { get; internal set; }
        public Face[] SdkResult { get; internal set; }
    }
}