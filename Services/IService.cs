namespace MovieTinder_API.Services
{
    public interface IService<ModelType>
    {
        public ModelType GetByID(int id);
        public bool Delete(ModelType modelType);
        public bool Save(ModelType modelType);
        public ModelType Create();
    }
}
