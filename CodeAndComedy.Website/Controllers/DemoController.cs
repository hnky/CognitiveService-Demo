using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CodeAndComedy.Website.Models.ViewModels;
using CodeAndComedy.Website.Utils;


using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;


using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;


namespace CodeAndComedy.Website.Controllers
{
    public class DemoController : Controller
    {
        private readonly string _baseUrl;
        public DemoController()
        {
            _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        }

        public async Task<ActionResult> TextInImages(string img)
        {
            img = string.IsNullOrWhiteSpace(img) ? "/images/Text/8.png" : img;

            var subscriptionKey = ConfigurationManager.AppSettings["VisionApiKey"];
            string imageUrl = $"{_baseUrl}{img}";

            // Using the SDK
            var visionService = new VisionServiceClient(subscriptionKey);
            OcrResults result = await visionService.RecognizeTextAsync(imageUrl);

            // Using the WebApi
            var url = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr";
            var requestService = new CognitiveServicesRequest();
            var response = await requestService.MakeRequest(url, subscriptionKey,requestService.CreateImageRequestObject(imageUrl));

            var viewModel = new TextInImagesViewModel
            {
                Result = result,
                JSONResult = response,
                ImageUrl = imageUrl,
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Face(string img)
        {
            img = string.IsNullOrWhiteSpace(img) ? "/images/face/5.jpg" : img;

            string subscriptionKey = ConfigurationManager.AppSettings["FaceApiKey"];
            string imageUrl = $"{_baseUrl}{img}";

            // Using the SDK
            var faceService = new FaceServiceClient(subscriptionKey);
            var result = await faceService.DetectAsync(imageUrl, true, true, new[] { FaceAttributeType.Age, FaceAttributeType.FacialHair,FaceAttributeType.Gender, FaceAttributeType.Glasses, FaceAttributeType.Smile});

            // Using the WebApi

            var viewmodel = new FaceViewModel
            {
                SdkResult = result,
                ImageUrl = imageUrl,
            };

            return View(viewmodel);
        }

        public async Task<ActionResult> Emotion(string img)
        {
            img = string.IsNullOrWhiteSpace(img) ? "/images/Emotions/pissed2.jpg" : img;
            string subscriptionKey = ConfigurationManager.AppSettings["EmotionApiKey"];
            string imageUrl = $"{_baseUrl}{img}";

            // Using the SDK



            EmotionServiceClient service = new EmotionServiceClient(subscriptionKey);
            Emotion[] result = await service.RecognizeAsync(imageUrl);



/*
            // Using the WebApi
            var url = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";
            var requestService = new CognitiveServicesRequest();
            var response = await requestService.MakeRequest(url, subscriptionKey, requestService.CreateImageRequestObject(imageUrl));
*/
            var viewModel = new EmotionViewModel
            {
                ImageUrl = imageUrl,
                SDKResult = result,
                JsonResponse = ""
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Object(string img)
        {
            img = string.IsNullOrWhiteSpace(img) ? "/images/Object/1.jpg" : img;
            var subscriptionKey = ConfigurationManager.AppSettings["VisionApiKey"];
            string imageUrl = $"{_baseUrl}{img}";

            // Using the SDK
            var client = new VisionServiceClient(subscriptionKey);
            AnalysisResult result = await client.AnalyzeImageAsync(imageUrl, new []{ VisualFeature.Description,VisualFeature.Categories} );

            // Using the WebApi
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["visualFeatures"] = "Categories,Tags,Description,Faces,ImageType,Color,Adult ";
            queryString["details"] = "Celebrities";
            queryString["language"] = "en";
            
            var url = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?"+queryString;
            var requestService = new CognitiveServicesRequest();
            var response = await requestService.MakeRequest(url, subscriptionKey,requestService.CreateImageRequestObject(imageUrl));

            var viewModel = new ObjectViewModel
            {
                ImageUrl = imageUrl,
                JsonResponse = response,
                SDKResult = result
            };

            return View(viewModel);
        }

        public async Task<ActionResult> TextAnalytics(string text)
        {
            text = string.IsNullOrWhiteSpace(text) ? "I had a wonderful experience! The rooms were wonderful and the staff were helpful." : text;
            var subscriptionKey = ConfigurationManager.AppSettings["TextApiKey"];
            var requestService = new CognitiveServicesRequest();
            var requestObject = requestService.CreateTextRequestObject(text);

            // Text Language API
            var urlLanguage = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages";
            var responseLanuage = await requestService.MakeRequest(urlLanguage, subscriptionKey, requestObject);

            // Text Topics API
            var urlTopics = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
            var responseTopics = await requestService.MakeRequest(urlTopics, subscriptionKey, requestObject);

            //Text Sentiment API
            var urlSentiment = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
            var responseSentiment = await requestService.MakeRequest(urlSentiment, subscriptionKey, requestObject);

            var viewModel = new TextAnalyticsViewModel
            {
                Text = text,
                JsonResponseLanuage = responseLanuage,
                JsonResponseTopics = responseTopics,
                JsonResponseSentiment = responseSentiment
            };

            return View(viewModel);
        }
    }
}