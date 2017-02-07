using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAndComedy.Website.Models.ViewModels
{
    public class TextAnalyticsViewModel
    {
        public string JsonResponseLanuage { get; set; }
        public string JsonResponseTopics { get; set; }
        public string JsonResponseSentiment { get; set; }
        public string Text { get; internal set; }
    }
}