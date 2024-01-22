using Microsoft.EntityFrameworkCore;
using RegistroDePrioridades.DAL;
using RegistroDePrioridades.Models;
using System.Linq.Expressions;

namespace RegistroDePrioridades.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _context;
        public PrioridadesBLL(Contexto contexto)
        {
            _context = contexto;
        }

        public async Task <bool> Guardar(Prioridades Prioridad)
        {
            if (! await Existe(Prioridad.PrioridadId))
                return await Insertar(Prioridad);
            else
                return await Modificar(Prioridad);
        }

        public async Task <bool> Insertar(Prioridades Prioridades)
        {
            _context.Prioridades.Add(Prioridades);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task <bool> Modificar(Prioridades Prioridades)
        {
            _context.Update(Prioridades);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task <bool> Existe(int PrioridadId)
        {
            return await _context.Prioridades
                .AnyAsync(p => p.PrioridadId == PrioridadId);

        }

        public async Task <bool> Eliminar(int id)
        {
            var prioridades =  await _context.Prioridades.
                Where(P => P.PrioridadId == id).ExecuteDeleteAsync();
            return prioridades > 0;
        }

        public async Task<Prioridades?> Buscar(int id)
        {
            return await _context.Prioridades.
                AsNoTracking()
                .FirstOrDefaultAsync(P => P.PrioridadId == id);
        }
        
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return _context.Prioridades.
                AsNoTracking()
                .Where(criterio)
                .ToList();

        }
    }
}
