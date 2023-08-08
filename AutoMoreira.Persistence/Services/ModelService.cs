namespace AutoMoreira.Persistence.Services
{
    public class ModelService : IModelService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        public ModelService(IBaseRepository baseRepository, IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<ModelDTO> AddModel(ModelDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<Model>(modelDTO);
                _baseRepository.Add<Model>(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _modelRepository.GetModelByIdAsync(model.Id);
                    return _mapper.Map<ModelDTO>(result);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO> UpdateModel(int modelId, ModelDTO modelDTO)
        {
            try
            {
                var model = await _modelRepository.GetModelByIdAsync(modelId);
                if (model == null) return null;

                modelDTO.Id = model.Id;

                _mapper.Map(modelDTO, model);

                _baseRepository.Update<Model>(model);

                if (await _baseRepository.SaveChangesAsync())
                {

                    var result = await _modelRepository.GetModelByIdAsync(model.Id);
                    return _mapper.Map<ModelDTO>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteModel(int modelId)
        {
            try
            {
                var model = await _modelRepository.GetModelByIdAsync(modelId);
                if (model == null) throw new Exception("Modelo não encontrado.");

                _baseRepository.Delete<Model>(model);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO[]> GetAllModelsAsync()
        {
            try
            {
                var models = await _modelRepository.GetAllModelsAsync();
                if (models == null) return null;

                return _mapper.Map<ModelDTO[]>(models);
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
                var model = await _modelRepository.GetModelByIdAsync(modelId);
                if (model == null) return null;

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO[]> GetModelsByMarkIdAsync(int markId)
        {
            try
            {
                var models = await _modelRepository.GetModelsByMarkIdAsync(markId);
                if (models == null) return null;

                return _mapper.Map<ModelDTO[]>(models);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
