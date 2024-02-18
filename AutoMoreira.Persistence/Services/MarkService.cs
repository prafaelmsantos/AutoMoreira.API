namespace AutoMoreira.Persistence.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly IMapper _mapper;

        public MarkService(IMarkRepository markRepository, IMapper mapper)
        {
            _markRepository = markRepository;
            _mapper = mapper;
        }

        public async Task<MarkDTO> AddMarkAsync(MarkDTO markDTO)
        {
            try
            {
                Mark mark = new(markDTO.Name);

                await _markRepository.AddAsync(mark);

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarkDTO> UpdateMarkAsync(MarkDTO markDTO)
        {
            try
            {
                var mark = await _markRepository.FindByIdAsync(markDTO.Id);

                if (mark == null) throw new Exception("Marca não encontrada.");

                mark.SetName(markDTO.Name);

                await _markRepository.UpdateAsync(mark);

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMark(int markId)
        {
            try
            {
                var mark = await _markRepository.FindByIdAsync(markId);

                if (mark == null) throw new Exception("Marca não encontrada.");

                
                return await _markRepository.RemoveAsync(mark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MarkDTO>> GetAllMarksAsync()
        {
            try
            {
                List<Mark> marks = await _markRepository.GetAll().OrderBy(x => x.Id).ToListAsync();

                return _mapper.Map<List<MarkDTO>>(marks);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarkDTO> GetMarkByIdAsync(int markId)
        {
            try
            {
                var mark = await _markRepository.FindByIdAsync(markId);

                if (mark == null) throw new Exception("Marca não encontrada.");

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
