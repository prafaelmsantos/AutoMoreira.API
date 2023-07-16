namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        Task<PageList<Veiculo>> GetAllVeiculosAsync(PageParams pageParams);
        Task<Veiculo> GetVeiculoByIdAsync(int veiculoId);
        Task<Veiculo[]> GetVeiculoByNovidadeAsync();
    }
}
