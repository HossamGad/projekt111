using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
	
    public interface INyProduktRepository
    {
        IEnumerable<NyProdukt> AllaNyProdukt { get; }

        IEnumerable<NyProdukt> GetAllNewProduct();
        IEnumerable<NyProdukt> GetNewProductByProductId(int CategoryId);
        IEnumerable<NyProdukt> GetNewProductByProductName(string Name);
        IEnumerable<NyProdukt> GetNewProductByProductText(string Text);
        IEnumerable<NyProdukt> GetNewProductByProductPrice(decimal Price);
               
        void CreateNewProductAndAddToDatabase(NyProdukt nyProdukt);

        
    }
}
