using Microsoft.EntityFrameworkCore;
using RegistroDePrioridades.Models;
using System.Linq.Expressions;
using RegistroDePrioridades.DAL;

namespace RegistroDePrioridades.Services
{
    public class SistemasService
    {
        private readonly Contexto _contexto;
        public SistemasService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Sistemas sistemas)
        {
            _contexto.Sistemas.Add(sistemas);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Sistemas sistemas)
        {
            var s = await _contexto.Sistemas.FindAsync(sistemas.SistemaId);
            _contexto.Entry(s!).State = EntityState.Detached;
            _contexto.Entry(sistemas).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public async Task<bool> Existe(int SistemaId)
        {
            return await _contexto.Sistemas
                .AnyAsync(c => c.SistemaId == SistemaId);
        }

        public async Task<bool> Guardar(Sistemas sistemas)
        {
            if (!await Existe(sistemas.SistemaId))
                return await Insertar(sistemas);
            else
                return await Modificar(sistemas);
        }

        public async Task<bool> Eliminar(Sistemas sistemas)
        {
            var cantidad = await _contexto.Sistemas
                .Where(p => p.SistemaId == sistemas.SistemaId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Sistemas?> Buscar(int SistemaId)
        {
            return await _contexto.Sistemas
                .Where(s => s.SistemaId == SistemaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public List<Sistemas> Listar(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}
