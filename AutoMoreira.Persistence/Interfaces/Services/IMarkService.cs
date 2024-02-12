﻿namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IMarkService
    {
        Task<MarkDTO> AddMarkAsync(MarkDTO markDTO);
        Task<MarkDTO> UpdateMarkAsync(MarkDTO markDTO);
        Task<bool> DeleteMark(int markId);

        Task<List<MarkDTO>> GetAllMarksAsync();
        Task<MarkDTO> GetMarkByIdAsync(int markId);
    }
}
