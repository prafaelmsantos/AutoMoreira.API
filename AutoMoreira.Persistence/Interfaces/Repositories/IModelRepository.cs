namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IModelRepository
    {
        Task<Model[]> GetAllModelsAsync();
        Task<Model> GetModelByIdAsync(int modelId);
        Task<Model[]> GetModelsByMarkIdAsync(int markId);
    }
}
