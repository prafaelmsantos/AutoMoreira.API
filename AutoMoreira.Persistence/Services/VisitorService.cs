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

        public async Task<List<VisitorDTO>> GetAllVisitoresAsync()
        {
            try
            {
                List<Visitor> visitors = await _visitorRepository
                    .GetAll()
                    .Where(x => x.Year == DateTime.UtcNow.Year)
                    .OrderBy( x=> x.Month)
                    .ToListAsync();

                List<VisitorDTO> visitorsDTO = _mapper.Map<List<VisitorDTO>>(visitors);

                List<MONTH> monthList = Enum.GetValues(typeof(MONTH)).Cast<MONTH>().ToList();

                var visitorsEmpty = visitorsDTO.Select(x => x.Month).Except(monthList).ToList();

                visitorsEmpty.ForEach(month => visitorsDTO.Add(new VisitorDTO() { Id = visitorsDTO.LastOrDefault().Id + 1, Month = month, Year = DateTime.UtcNow.Year, Value = 0 }));

                int lastValue = visitorsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month)?.FirstOrDefault()?.Value ?? 0;
                int currentValue = visitorsDTO.Where(x => (int)x.Month == DateTime.UtcNow.Month - 1)?.FirstOrDefault()?.Value ?? 0;
                double valuePerc = (double)(currentValue - lastValue) / lastValue * 100;

                /*foreach (MONTH month in visitorsEmpty)
                { 
                    visitorsDTO.Add( new VisitorDTO() { Id = visitorsDTO.LastOrDefault().Id + 1, Month = month, Year = year, Value = 0 });
                }*/

                return visitorsDTO;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VisitorDTO> CreateOrUpdateVisitorAsync(MONTH month)
        {
            try
            {
                Visitor visitor = await _visitorRepository
                    .GetAll()
                    .Where(x => x.Year == DateTime.UtcNow.Year && x.Month == month)
                    .FirstOrDefaultAsync();

                if (visitor is null)
                {
                    visitor = new Visitor(month);
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
    }
}
