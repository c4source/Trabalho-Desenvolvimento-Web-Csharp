using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class MedicoService
    {
        private readonly AppDbContext _context;

        public MedicoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Medico> Listar()
        {
            return _context.Medicos
                .OrderBy(m => m.Id)
                .ToList();
        }

        public void Inserir(Medico obj)
        {
            _context.Medicos.Add(obj);
            _context.SaveChanges();
        }

        public Medico? EncontrarId(int id)
        {
            return _context.Medicos.Find(id);
        }

        public void Remover(int id)
        {
            var obj = _context.Medicos.Find(id);

            if (obj == null)
            {
                return;
            }

            _context.Medicos.Remove(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Medico obj)
        {
            _context.Medicos.Update(obj);
            _context.SaveChanges();
        }
    }
}