﻿namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IModelService
    {
        Task<ModelDTO> AddModelAsync(ModelDTO modelDTO);
        Task<ModelDTO> UpdateModelAsync(ModelDTO modelDTO);
        Task<List<ResponseMessageDTO>> DeleteModelsAsync(List<int> modelsIds);

        Task<List<ModelDTO>> GetAllModelsAsync();
        Task<ModelDTO> GetModelByIdAsync(int modelId);
        Task<List<ModelDTO>> GetModelsByMarkIdAsync(int markId);
    }
}
