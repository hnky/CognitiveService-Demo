using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CodeAndComedy.Website.Models.ViewModels
{
    public class TextInImagesViewModel
    {
        public string ImageUrl { get; internal set; }
        public string JSONResult { get; set; }
        public OcrResults Result { get; set; }
    }
}