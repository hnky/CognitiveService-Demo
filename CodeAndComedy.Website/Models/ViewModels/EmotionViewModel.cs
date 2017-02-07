using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace CodeAndComedy.Website.Models.ViewModels
{
    public class EmotionViewModel
    {
        public string ImageUrl { get; set; }
        public string JsonResponse { get; set; }
        public Emotion[] SDKResult { get; set; }
    }
}