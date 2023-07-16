namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<VeiculoDTO> AddVeiculos(VeiculoDTO model);
        Task<VeiculoDTO> UpdateVeiculo(int veiculoId, VeiculoDTO model);
        Task<bool> DeleteVeiculo(int veiculoId);

        Task<PageList<VeiculoDTO>> GetAllVeiculosAsync(PageParams pageParams);
        Task<VeiculoDTO> GetVeiculoByIdAsync(int veiculoId);
        Task<VeiculoDTO[]> GetVeiculoByNovidadeAsync();
    }
}
