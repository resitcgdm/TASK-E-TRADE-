using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal=productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();    
        }
        public Product GetById(int productId)
        {
            return _productDal.GetById(x => x.Id == productId);

        }
        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(x=>x.CategoryId==id);

        }

        public Product GetId(int id)
        {
            return _productDal.GetId(id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
