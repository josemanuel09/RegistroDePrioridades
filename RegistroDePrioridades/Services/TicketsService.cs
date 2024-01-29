using RegistroDePrioridades.DAL;
using RegistroDePrioridades.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RegistroDePrioridades.Services
{
    public class TicketsService
    {
        private readonly Contexto _contexto;
        public TicketsService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Tickets tickets)
        {
            _contexto.Tickets.Add(tickets);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tickets tickets)
        {
            var t = await _contexto.Tickets.FindAsync(tickets.TicketId);
            _contexto.Entry(t!).State = EntityState.Detached;
            _contexto.Entry(tickets).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public async Task<bool> Existe(int TicketId)
        {
            return await _contexto.Tickets
                .AnyAsync(c => c.TicketId == TicketId);
        }

        public async Task<bool> Guardar(Tickets tickets)
        {
            if (!await Existe(tickets.TicketId))
                return await Insertar(tickets);
            else
                return await Modificar(tickets);
        }

        public async Task<bool> Eliminar(Tickets tickets)
        {
            var cantidad = await _contexto.Tickets
                .Where(p => p.TicketId == tickets.TicketId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Tickets?> Buscar(int TicketId)
        {
            return await _contexto.Tickets
                .Where(t => t.TicketId == TicketId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.Tickets
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}
