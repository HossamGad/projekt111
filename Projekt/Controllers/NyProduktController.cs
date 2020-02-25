using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt.Controllers
{
	public class NyProduktController : Controller
	{
        private readonly INyProduktRepository _NyProduktRepository;
        private readonly IProdukterRepository _produkterRepository;

        public NyProduktController(INyProduktRepository NyProduktRepository, IProdukterRepository produkterRepository)
        {
            _NyProduktRepository = NyProduktRepository;
            _produkterRepository = produkterRepository;
        }

        public IActionResult CommentaryD(int CategoryId)
        {
            NyProdukt nyProdukt = new NyProdukt();
            var Category = _produkterRepository.GetProduktById(CategoryId);
            nyProdukt.CategoryId = Category.CategoryId;



            return View(nyProdukt);
        }

        [HttpPost]
        public IActionResult CommentaryD(NyProdukt newCommentary)
        {


            if (newCommentary.CommentMessage == "")
            {
                ModelState.AddModelError("", "Please insert Your Review is empty");
            }

            if (ModelState.IsValid)
            {

                _CommentaryRepository.CreateCommentUpdateDatabase(newCommentary);
                return RedirectToAction("ReviewComplete");
            }

            return View(newCommentary);
        }

        public IActionResult ReviewComplete()
        {
            ViewBag.ReviewCompleteMessage = "Thank you";
            return View();
        }
    }
}
