using WebApp.Data.Entities;

namespace WebApp.BL.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }

    public abstract class RepositoryBase<TEntity>
        : IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly MyShopContext _shopContext;
        protected RepositoryBase(MyShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _shopContext.Add(entity);
            _shopContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(int id)
        {
            var entity = Get(id);
            _shopContext.Remove(entity);
            _shopContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Get(int id)
        {
            return _shopContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<TEntity> GetAll()
        {
            return _shopContext.Set<TEntity>().ToList();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _shopContext.Update(entity);
            _shopContext.SaveChanges();
            return entity;
        }
    }

    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(MyShopContext shopContext) : base(shopContext)
        {
        }
        public override List<Category> GetAll()
        {
            return _shopContext.Categories.OrderBy(x => x.Name).ToList();
        }
    }

    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(MyShopContext shopContext) : base(shopContext)
        {
        }        
    }
}
