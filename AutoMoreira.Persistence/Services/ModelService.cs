﻿namespace AutoMoreira.Persistence.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<ModelDTO> AddModelAsync(ModelDTO modelDTO)
        {
            try
            {
                Model model = new(modelDTO.Name, modelDTO.MarkId);

                await _modelRepository.AddAsync(model);

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO> UpdateModelAsync(ModelDTO modelDTO)
        {
            try
            {
                Model model = await _modelRepository.FindByIdAsync(modelDTO.Id) ?? throw new Exception("Modelo não encontrado.");
                model.UpdateModel(modelDTO.Name, modelDTO.MarkId);

                await _modelRepository.UpdateAsync(model);

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ResponseMessageDTO>> DeleteModelsAsync(List<int> modelsIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int modelId in modelsIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = modelId }, OperationSuccess = false };
                try
                {
                    Model? model = await _modelRepository.FindByIdAsync(modelId);

                    if (model is not null)
                    {
                        responseMessageDTO.Entity.Name = model.Name;

                        await _modelRepository.RemoveAsync(model);
                        responseMessageDTO.OperationSuccess = true;
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = "Modelo não encontrado.";
                    }
                }

                catch (Exception ex)
                {
                    responseMessageDTO.ErrorMessage = ex.Message;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        public async Task<List<ModelDTO>> GetAllModelsAsync()
        {
            try
            {
                List<Model> models = await _modelRepository
                    .GetAll()
                    .Include(x => x.Mark)
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<ModelDTO>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO> GetModelByIdAsync(int modelId)
        {
            try
            {
                Model? model = await _modelRepository
                    .GetAll()
                    .Where(x => x.Id == modelId)
                    .Include(x => x.Mark)
                    .FirstOrDefaultAsync() ?? throw new Exception("Modelo não encontrado.");

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ModelDTO>> GetModelsByMarkIdAsync(int markId)
        {
            try
            {
                List<Model> models = await _modelRepository
                    .GetAll()
                    .Where(x=> x.MarkId == markId)
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<ModelDTO>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
