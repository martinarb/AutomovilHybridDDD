using Application.Interfaces;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AutomovilService : IAutomovilService
    {
        private readonly AutomovilDbContext _context;

        public AutomovilService(AutomovilDbContext context)
        {
            _context = context;
        }

        public async Task<AutomovilDto> CrearAsync(CrearAutomovilDto dto)
        {
            var automovil = new Automovil(dto.Marca, dto.Modelo, dto.Color, dto.Fabricacion, dto.NumeroMotor, dto.NumeroChasis);
            _context.Automoviles.Add(automovil);
            await _context.SaveChangesAsync();

            return new AutomovilDto
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Color = automovil.Color,
                Fabricacion = automovil.Fabricacion,
                NumeroMotor = automovil.NumeroMotor,
                NumeroChasis = automovil.NumeroChasis
            };
        }

        public async Task<AutomovilDto?> ActualizarAsync(int id, ActualizarAutomovilDto dto)
        {
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil == null) return null;

            automovil.Actualizar(dto.Marca, dto.Modelo, dto.Color, dto.Fabricacion, dto.NumeroMotor, dto.NumeroChasis);
            await _context.SaveChangesAsync();

            return new AutomovilDto
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Color = automovil.Color,
                Fabricacion = automovil.Fabricacion,
                NumeroMotor = automovil.NumeroMotor,
                NumeroChasis = automovil.NumeroChasis
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil == null) return false;

            _context.Automoviles.Remove(automovil);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AutomovilDto?> ObtenerPorIdAsync(int id)
        {
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil == null) return null;

            return new AutomovilDto
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Color = automovil.Color,
                Fabricacion = automovil.Fabricacion,
                NumeroMotor = automovil.NumeroMotor,
                NumeroChasis = automovil.NumeroChasis
            };
        }

        public async Task<AutomovilDto?> ObtenerPorChasisAsync(string numeroChasis)
        {
            var automovil = await _context.Automoviles.FirstOrDefaultAsync(a => a.NumeroChasis == numeroChasis);
            if (automovil == null) return null;

            return new AutomovilDto
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Color = automovil.Color,
                Fabricacion = automovil.Fabricacion,
                NumeroMotor = automovil.NumeroMotor,
                NumeroChasis = automovil.NumeroChasis
            };
        }

        public async Task<IEnumerable<AutomovilDto>> ObtenerTodosAsync()
        {
            var autos = await _context.Automoviles.ToListAsync();
            var dtos = new List<AutomovilDto>();
            foreach (var a in autos)
            {
                dtos.Add(new AutomovilDto
                {
                    Id = a.Id,
                    Marca = a.Marca,
                    Modelo = a.Modelo,
                    Color = a.Color,
                    Fabricacion = a.Fabricacion,
                    NumeroMotor = a.NumeroMotor,
                    NumeroChasis = a.NumeroChasis
                });
            }
            return dtos;
        }
    }
}
