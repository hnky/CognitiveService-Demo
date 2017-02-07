using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;

namespace CodeAndComedy.Website.Models.ViewModels
{
    public class ObjectViewModel
    {
        public string ImageUrl { get; internal set; }
        public string JsonResponse { get; internal set; }
        public AnalysisResult SDKResult { get; internal set; }
    }
}