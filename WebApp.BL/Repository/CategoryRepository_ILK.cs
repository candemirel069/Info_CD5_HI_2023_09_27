using WebApp.Data.Entities;

namespace WebApp.BL.Repository
{
    public class CategoryRepository_ILK : IRepositoryBase<Category>
    {
        private readonly MyShopContext _context;
        public CategoryRepository_ILK(MyShopContext context)
        {
            _context = context;
        }
        public Category Add(Category entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Category Delete(int id)
        {
            var entity = _context.Set<Category>().FirstOrDefault(x=>x.Id==id);
            _context.Remove(entity);
            _context.SaveChanges();
            return entity;  
        }

        public Category Get(int id)
        {
           return _context.Set<Category>().FirstOrDefault(x => x.Id == id);
        }

        public List<Category> GetAll()
        {
            return _context.Set<Category>().ToList();
        }

        public Category Update(Category entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
