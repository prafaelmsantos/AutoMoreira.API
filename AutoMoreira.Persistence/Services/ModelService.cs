namespace AutoMoreira.Persistence.Services
{
    public class ModelService : IModelService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;

        #endregion

        #region Constructors

        public ModelService(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;         
        }

        #endregion

        #region Public methods

        public async Task<List<ModelDTO>> GetAllModelsAsync()
        {
            try
            {
                List<Model> models = await _modelRepository
                    .GetAll()
                    .Include(x => x.Mark)
                    .OrderBy(x => x.Id)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<ModelDTO>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllModelsAsyncException} {ex.Message}");
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
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                model.ThrowIfNull(() => throw new Exception(DomainResource.ModelNotFoundException));

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetModelByIdAsyncException} {ex.Message}");
            }
        }
        
        public async Task<List<ModelDTO>> GetModelsByMarkIdAsync(int markId)
        {
            try
            {
                List<Model> models = await _modelRepository
                    .GetAll()
                    .Where(x => x.MarkId == markId)
                    .OrderBy(x => x.Id)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<ModelDTO>>(models);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetModelsByMarkIdAsyncException} {ex.Message}");
            }
        }
       
        public async Task<ModelDTO> AddModelAsync(ModelDTO modelDTO)
        {
            try
            {
                ModelExistsAsync(modelDTO).Result
                    .Throw(() => throw new Exception(DomainResource.ModelAlreadyExistsException))
                    .IfTrue();

                Model model = new(modelDTO.Name, modelDTO.MarkId);

                await _modelRepository.AddAsync(model);

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.AddModelAsyncException} {ex.Message}");
            }
        }

        public async Task<ModelDTO> UpdateModelAsync(ModelDTO modelDTO)
        {
            try
            {
                Model? model = await _modelRepository.FindByIdAsync(modelDTO.Id);

                model.ThrowIfNull(() => throw new Exception(DomainResource.ModelNotFoundException));

                ModelExistsAsync(modelDTO).Result
                    .Throw(() => throw new Exception(DomainResource.ModelAlreadyExistsException))
                    .IfTrue();

                model.UpdateModel(modelDTO.Name, modelDTO.MarkId);

                await _modelRepository.UpdateAsync(model);

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateModelAsyncException} {ex.Message}");
            }
        }  

        public async Task<List<ResponseMessageDTO>> DeleteModelsAsync(List<int> modelsIds)
        {
            return await DeleteModels(modelsIds);
        }

        #endregion

        #region Private methods

        private async Task<bool> ModelExistsAsync(ModelDTO modelDTO)
        {
            return await _modelRepository
                    .GetAll()
                    .AnyAsync(x => x.Id != modelDTO.Id && x.Name.Trim().ToLower() == modelDTO.Name.ToLower());
        }

        private async Task<List<ResponseMessageDTO>> DeleteModels(List<int> modelsIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int markId in modelsIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = markId }, OperationSuccess = false };
                try
                {
                    Model? model = await _modelRepository.FindByIdAsync(markId);

                    if (model is not null)
                    {
                        responseMessageDTO.Entity.Name = model.Name;
                        responseMessageDTO.OperationSuccess = await _modelRepository.RemoveAsync(model);
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.ModelNotFoundException;
                    }
                }
                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteModelsAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}
