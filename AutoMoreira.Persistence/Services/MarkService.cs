namespace AutoMoreira.Persistence.Services
{
    public class MarkService : IMarkService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMarkRepository _markRepository;
        private readonly IMapper _mapper;

        public MarkService(
        IBaseRepository baseRepository,
        IMarkRepository markRepository,
        IMapper mapper)
        {
            _baseRepository = baseRepository;
            _markRepository = markRepository;
            _mapper = mapper;

        }

        public async Task<MarkDTO> AddMark(MarkDTO markDTO)
        {
            try
            {
                var mark = _mapper.Map<Mark>(markDTO);
                _baseRepository.Add<Mark>(mark);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _markRepository.GetMarkByIdAsync(mark.Id);
                    return _mapper.Map<MarkDTO>(result);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarkDTO> UpdateMark(int markId, MarkDTO markDTO)
        {
            try
            {
                var mark = await _markRepository.GetMarkByIdAsync(markId);
                if (mark == null) return null;

                markDTO.Id = mark.Id;

                _mapper.Map(markDTO, mark);

                _baseRepository.Update<Mark>(mark);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var result = await _markRepository.GetMarkByIdAsync(mark.Id);
                    return _mapper.Map<MarkDTO>(result);

                }
                return null;
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
                var mark = await _markRepository.GetMarkByIdAsync(markId);
                if (mark == null) throw new Exception("Marca não encontrada.");

                _baseRepository.Delete<Mark>(mark);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarkDTO[]> GetAllMarksAsync()
        {
            try
            {
                var marks = await _markRepository.GetAllMarksAsync();
                if (marks == null) return null;

                return _mapper.Map<MarkDTO[]>(marks);

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
                var mark = await _markRepository.GetMarkByIdAsync(markId);
                if (mark == null) return null;

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
