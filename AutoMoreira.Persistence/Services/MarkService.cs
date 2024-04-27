namespace AutoMoreira.Persistence.Services
{
    public class MarkService : IMarkService
    {
        #region Private variables

        private readonly IMapper _mapper;
        private readonly IMarkRepository _markRepository;

        #endregion

        #region Constructors
        public MarkService(IMapper mapper, IMarkRepository markRepository)
        {
            _mapper = mapper;
            _markRepository = markRepository;
        }
        #endregion

        #region Public methods

        public async Task<List<MarkDTO>> GetAllMarksAsync()
        {
            try
            {
                List<Mark> marks = await _markRepository
                    .GetAll()
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                return _mapper.Map<List<MarkDTO>>(marks);

            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetAllMarksAsyncException} {ex.Message}");
            }
        }

        public async Task<MarkDTO> GetMarkByIdAsync(int markId)
        {
            try
            {
                Mark? mark = await _markRepository.FindByIdAsync(markId);

                mark.ThrowIfNull(() => throw new Exception(DomainResource.MarkNotFoundException));

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.GetMarkByIdAsyncException} {ex.Message}");
            }
        }
        
        public async Task<MarkDTO> AddMarkAsync(MarkDTO markDTO)
        {
            try
            {
                MarkExistsAsync(markDTO).Result
                    .Throw(() => throw new Exception(DomainResource.MarkAlreadyExistsException))
                    .IfTrue();
                
                Mark mark = new(markDTO.Name);

                mark = await _markRepository.AddAsync(mark);

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.AddMarkAsyncException} {ex.Message}");
            }
        }

        public async Task<MarkDTO> UpdateMarkAsync(MarkDTO markDTO)
        {
            try
            {
                Mark? mark = await _markRepository.FindByIdAsync(markDTO.Id);

                mark.ThrowIfNull(() => throw new Exception(DomainResource.MarkNotFoundException));

                MarkExistsAsync(markDTO).Result
                    .Throw(() => throw new Exception(DomainResource.MarkAlreadyExistsException))
                    .IfTrue();

                mark.SetName(markDTO.Name);

                mark = await _markRepository.UpdateAsync(mark);

                return _mapper.Map<MarkDTO>(mark);
            }
            catch (Exception ex)
            {
                throw new Exception($"{DomainResource.UpdateMarkAsyncException} {ex.Message}");
            }
        }     

        public async Task<List<ResponseMessageDTO>> DeleteMarksAsync(List<int> marksIds)
        {
            return await DeleteMarks(marksIds);
        }

        #endregion

        #region Private methods

        private async Task<bool> MarkExistsAsync(MarkDTO markDTO)
        {
            return await _markRepository
                    .GetAll()
                    .AnyAsync(x => x.Id != markDTO.Id && x.Name.Trim().ToLower() == markDTO.Name.ToLower());
        }

        private async Task<List<ResponseMessageDTO>> DeleteMarks(List<int> marksIds)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new();

            foreach (int markId in marksIds)
            {
                ResponseMessageDTO responseMessageDTO = new() { Entity = new MinimumDTO() { Id = markId }, OperationSuccess = false };
                try
                {
                    Mark? mark = await _markRepository.FindByIdAsync(markId);

                    if (mark is not null)
                    {
                        responseMessageDTO.Entity.Name = mark.Name;
                        responseMessageDTO.OperationSuccess = await _markRepository.RemoveAsync(mark);
                    }
                    else
                    {
                        responseMessageDTO.ErrorMessage = DomainResource.MarkNotFoundException;
                    }
                }
                catch (Exception)
                {
                    responseMessageDTO.ErrorMessage = DomainResource.DeleteMarksAsyncException;
                }

                responseMessageDTOs.Add(responseMessageDTO);
            }

            return responseMessageDTOs;
        }

        #endregion
    }
}
