using Domain.Entities;
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAutomovilService
    {
        Task<AutomovilDto> CrearAsync(CrearAutomovilDto dto);
        Task<AutomovilDto?> ActualizarAsync(int id, ActualizarAutomovilDto dto);
        Task<bool> EliminarAsync(int id);
        Task<AutomovilDto?> ObtenerPorIdAsync(int id);
        Task<AutomovilDto?> ObtenerPorChasisAsync(string numeroChasis);
        Task<IEnumerable<AutomovilDto>> ObtenerTodosAsync();
    }
}
