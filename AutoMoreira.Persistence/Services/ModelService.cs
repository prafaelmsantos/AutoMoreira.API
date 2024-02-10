namespace AutoMoreira.Persistence.Services
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
                Model model = _mapper.Map<Model>(modelDTO);

                await _modelRepository.AddAsync(model);

                return _mapper.Map<ModelDTO>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModelDTO> UpdateModelAsync(int modelId, ModelDTO modelDTO)
        {
            try
            {
                Model model = await _modelRepository.FindByIdAsync(modelId);

                if (model == null) throw new Exception("Modelo não encontrado.");

                modelDTO.Id = model.Id;

                _mapper.Map(modelDTO, model);

                await _modelRepository.UpdateAsync(model);

                return _mapper.Map<ModelDTO>(model);
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
                Model model = await _modelRepository.FindByIdAsync(modelId);

                if (model == null) throw new Exception("Modelo não encontrado.");

                return await _modelRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ModelDTO>> GetAllModelsAsync()
        {
            try
            {
                List<Model> models = await _modelRepository
                    .GetAll()
                    .Include(x => x.Mark)
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
                Model model = await _modelRepository
                    .GetAll()
                    .Where(x => x.Id == modelId)
                    .Include(x => x.Mark)
                    .FirstOrDefaultAsync();

                if (model == null) throw new Exception("Modelo não encontrado.");

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
