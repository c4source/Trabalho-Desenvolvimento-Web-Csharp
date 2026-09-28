using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class PacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {

            _context = context;

        }

        //Add listar
        public List<Paciente> Listar()
        {
            return _context.Pacientes
                .OrderBy(m => m.Id)
                .ToList();
        }

        public Paciente? EncontrarId(int id) 
        {

            return _context.Pacientes.Find(id);
        
        }

        //Inserir
        public void Inserir(Paciente paciente) 
        {
        
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        
        }

        //Remover
        public void Deletar(int id) 
        {
            var obj = _context.Pacientes.Find(id);

            if (obj != null) 
            {
            
                _context.Pacientes.Remove(obj);
                _context.SaveChanges();
            
            }
        
        }

      
    }
}
