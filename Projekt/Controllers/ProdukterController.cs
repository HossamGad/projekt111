using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projekt.Controllers
{
	public class ProdukterController : Controller
	{

        private readonly IProdukterRepository _produkterRepository;
        private readonly ICategoryRepository _categoryRepository;
        //private readonly ICommentary _commentaryRepository;

        public ProdukterController(IProdukterRepository produkterRepository, ICategoryRepository categoryRepository)
        {
            _produkterRepository = produkterRepository;
            _categoryRepository = categoryRepository;
           // _commentaryRepository = commentaryRepository;
        }


        public ViewResult List(string category)
        {
            IEnumerable<Produkter> produkter;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                produkter = _produkterRepository.AllProdukter.OrderBy(p => p.ProduktId);
                currentCategory = " ";
            }
            else
            {
                produkter = _produkterRepository.AllProdukter.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ProduktId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ProdukterListViewModel
            {
                Produkter = produkter,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var produkter = _produkterRepository.GetPieById(id);
            if (produkter == null)
                return NotFound();

            

            return View(produkter);
        }
    }
}
