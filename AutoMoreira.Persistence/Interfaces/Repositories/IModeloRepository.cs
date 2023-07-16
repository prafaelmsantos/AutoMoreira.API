namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IModeloRepository
    {
        Task<Modelo[]> GetAllModelosAsync();
        Task<Modelo> GetModeloByIdAsync(int modeloId);
        Task<Modelo[]> GetModeloByMarcaIdAsync(int marcaId);
    }
}
