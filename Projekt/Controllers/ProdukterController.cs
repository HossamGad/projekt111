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

		public ProdukterController(IProdukterRepository ProdkterRepository, ICategoryRepository categoryRepository)
		{
			_produkterRepository = ProdkterRepository;
			_categoryRepository = categoryRepository;
		}
		
		public ViewResult List()
		{
			ProdukterListViewModel produkterListViewModel = new ProdukterListViewModel();
			produkterListViewModel.Produkter = _produkterRepository.AllProdukter;

			produkterListViewModel.CurrentCategory = "Produkter";
			return View(produkterListViewModel);
		}
	}
}
