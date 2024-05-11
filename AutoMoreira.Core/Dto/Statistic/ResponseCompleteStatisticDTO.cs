namespace AutoMoreira.Core.Dto.Statistic
{
    public class ResponseCompleteStatisticDTO : ResponseStatisticDTO
    {
        public List<StatisticDTO> LastStatistics { get; set; } = new();
    }
}
