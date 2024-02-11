using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public List<Category> GetList()
        {
            return _categorydal.GetListAll();
        }

        public List<Category> GetActiveList()
        {
            return _categorydal.GetListAll(x => !x.IsDeleted);
        }

        public void TAdd(Category t)
        {
            _categorydal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categorydal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categorydal.GetById(id);
        }

        public void TUpdate(Category t)
        {
            _categorydal.Update(t);
        }
    }
}
