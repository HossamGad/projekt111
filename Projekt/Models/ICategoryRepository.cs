using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> AllCategories { get; }
		Category GetCategoryById(int CategoryId);
	}
}
