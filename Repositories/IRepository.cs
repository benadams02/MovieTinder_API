namespace MovieTinder_API.Repositories
{
    public interface IRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T GetByID(int ID);
        public bool Save(T ObjIn);
        public bool Delete(T ObjIn);
        public bool Update(T ObjIn);
    }
}
