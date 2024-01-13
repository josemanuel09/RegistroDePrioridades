using Microsoft.EntityFrameworkCore;
using RegistroDePrioridades.DAL;
using RegistroDePrioridades.Models;
using System.Linq.Expressions;

namespace RegistroDePrioridades.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == PrioridadId);

        }

        public bool Guardar(Prioridades Prioridades)
        {
            if (!Existe(Prioridades.PrioridadId))
                return this.Insertar(Prioridades);
            else
                return this.Modificar(Prioridades);
        }

        public bool Eliminar(int id)
        {
            var prioridades = _contexto.Prioridades.Find(id);
            _contexto.Prioridades.Remove(prioridades);
            var deleted = _contexto.SaveChanges() > 0;
            return deleted;
        }

        public async Task<Prioridades?> Buscar(int id)
        {
            return await _contexto.Prioridades.FindAsync(id);
        }
        public bool Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridades.Add(Prioridades);
            return _contexto.SaveChanges() > 0;
        }

        public bool Modificar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return _contexto.Prioridades.Where(criterio).AsNoTracking().ToList();
        }

    }
}
