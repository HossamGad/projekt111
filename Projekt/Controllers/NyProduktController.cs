using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt.Controllers
{
    [Authorize]
    public class NyProduktController : Controller
	{
        private readonly INyProduktRepository _NyProduktRepository;
        private readonly IProdukterRepository _ProdukterRepository;

        public NyProduktController(INyProduktRepository NyProduktRepository, IProdukterRepository produkterRepository)
        {
            _NyProduktRepository = NyProduktRepository;
            _ProdukterRepository = produkterRepository;
        }

        public IActionResult NyProdukt(int ProduktId)
        {
            NyProdukt nyProdukt = new NyProdukt();
            var Produkt = _ProdukterRepository.GetProductById(ProduktId);
            nyProdukt.ProduktId = Produkt.ProduktId;



            return View(nyProdukt);
        }

        [HttpPost]
        public IActionResult NyProdukt(NyProdukt nyProdukt)
        {


            if (nyProdukt.Name == "")
            {
                ModelState.AddModelError("", "Please insert the of the product");
            }

            if (ModelState.IsValid)
            {

                _NyProduktRepository.CreateNewProductAndAddToDatabase(nyProdukt);
                return RedirectToAction("Complete");
            }

            return View(nyProdukt);
        }

        public IActionResult Complete()
        {
            ViewBag.Complete = "Thank you";
            return View();
        }
    }
}
