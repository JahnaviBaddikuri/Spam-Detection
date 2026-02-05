using Microsoft.AspNetCore.Mvc;
using SpamClassifierWebApp.Models;
using SpamTextClassifierLibrary;
using System.Diagnostics;

namespace SpamClassifierWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        public ActionResult Index()
        {
            return View(new SpamCheckViewModel());
        }

        [HttpPost]
        public ActionResult Index(SpamCheckViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.InputText))
            {
                SpamClassificationModel.ModelInput sampleData = new SpamClassificationModel.ModelInput()
                {
                    Col1 = model.InputText,
                };

                var sortedScoresWithLabel = SpamClassificationModel.PredictAllLabels(sampleData);
                
                model.SpamProbability = sortedScoresWithLabel.FirstOrDefault((x => x.Key == "spam")).Value;
                model.SpamProbability = model.SpamProbability * 100;

                model.IsSpam = model.SpamProbability > 5;
            }

            return View(model);
        }
    }
}
