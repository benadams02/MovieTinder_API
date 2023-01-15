namespace MovieTinder_API.Repositories
{
    public class GenericRepository<ModelType> : IRepository<ModelType> where ModelType : class
    {
        private Type thisType;
        public GenericRepository()
        {
            thisType = typeof(ModelType);
        }

        public bool Delete(ModelType ObjIn)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ModelType> GetAll()
        {
            throw new NotImplementedException();
        }

        public ModelType GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Save(ModelType ObjIn)
        {
            throw new NotImplementedException();
        }

        public bool Update(ModelType ObjIn)
        {
            throw new NotImplementedException();
        }
    }
}
