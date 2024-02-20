namespace AutoMoreira.Persistence.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorService(IVisitorRepository visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCompleteVisitorDTO> GetAllVisitoresWithYearComparisonAsync()
        {
            try
            {
                List<VisitorDTO> currentVisitors = await GetAllVisitoresByYear(DateTime.UtcNow.Year);
                List<VisitorDTO> lastVisitors = await GetAllVisitoresByYear(DateTime.UtcNow.Year - 1);

                long lastValue = lastVisitors.Select( x => x.Value).Sum();
                long currentValue = currentVisitors.Select(x => x.Value).Sum();
                double valuePerc = lastValue != 0 ? (double)(currentValue - lastValue) / lastValue * 100 : currentValue != 0 ? 100 : 0;

                return new ResponseCompleteVisitorDTO() 
                { 
                    Visitors = currentVisitors, 
                    LastVisitors = lastVisitors, 
                    ValuePerc = valuePerc, 
                    Value = currentValue
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseVisitorDTO> GetAllVisitoresWithMonthComparisonAsync()
        {
            try
            {
                List<VisitorDTO> visitorsDTO = await GetAllVisitoresByYear(DateTime.UtcNow.Year);

                long currentMonthValue = visitorsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month)?.FirstOrDefault()?.Value ?? 0;
                long lastMonthValue = visitorsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month - 1)?.FirstOrDefault()?.Value ?? 0;
                double valuePerc = lastMonthValue != 0 ? (double)(currentMonthValue - lastMonthValue) / lastMonthValue * 100 : currentMonthValue !=0 ? 100 : 0;

                return new ResponseVisitorDTO() 
                { 
                    Visitors = visitorsDTO, 
                    ValuePerc = valuePerc, 
                    Value = currentMonthValue
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitorCounterDTO> GetAllVisitoresCountersAsync()
        {
            try
            {
                List<VisitorDTO> visitorsDTO = await GetAllVisitoresByYear(DateTime.UtcNow.Year);

                return new VisitorCounterDTO()
                {
                    Total = visitorsDTO.Select(x => x.Value).Sum(),
                    TotalMonth = visitorsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month)?.FirstOrDefault()?.Value ?? 0
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitorDTO> CreateOrUpdateVisitorAsync()
        {
            try
            {
                Visitor visitor = await _visitorRepository
                    .GetAll()
                    .Where(x => x.Year == DateTime.UtcNow.Year && (int)x.Month == DateTime.UtcNow.Month)
                    .FirstOrDefaultAsync();

                if (visitor is null)
                {
                    visitor = new Visitor();
                    await _visitorRepository.AddAsync(visitor);
                }
                else
                {
                    visitor.SetValue();
                    await _visitorRepository.UpdateAsync(visitor);
                }

                return _mapper.Map<VisitorDTO>(visitor);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        #region Private methods
        private async Task<List<VisitorDTO>> GetAllVisitoresByYear(int year)
        {
            try
            {
                List<Visitor> visitors = await _visitorRepository
                    .GetAll()
                    .Where(x => x.Year == year)
                    .ToListAsync();

                List<VisitorDTO> visitorsDTO = _mapper.Map<List<VisitorDTO>>(visitors);

                List<MONTH> monthList = Enum.GetValues(typeof(MONTH)).Cast<MONTH>().ToList();

                var visitorsEmpty = monthList.Except(visitorsDTO.Select(x => x.Month)).ToList();

                visitorsEmpty.ForEach(month => 
                    visitorsDTO.Add(new VisitorDTO() { Month = month, Year = DateTime.UtcNow.Year, Value = 0 }));

                return visitorsDTO.OrderBy(x => x.Month).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
