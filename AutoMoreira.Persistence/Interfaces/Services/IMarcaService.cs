namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<MarcaDTO> AddMarcas(MarcaDTO model);
        Task<MarcaDTO> UpdateMarca(int marcaId, MarcaDTO model);
        Task<bool> DeleteMarca(int marcaId);

        Task<MarcaDTO[]> GetAllMarcasAsync();
        Task<MarcaDTO> GetMarcaByIdAsync(int marcaId);
    }
}
