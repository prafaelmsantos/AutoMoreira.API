namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IModelService
    {
        Task<ModelDTO> AddModel(ModelDTO modelDTO);
        Task<ModelDTO> UpdateModel(int modelId, ModelDTO modelDTO);
        Task<bool> DeleteModel(int modelId);

        Task<List<ModelDTO>> GetAllModelsAsync();
        Task<ModelDTO> GetModelByIdAsync(int modelId);
        Task<List<ModelDTO>> GetModelsByMarkIdAsync(int markId);
    }
}
