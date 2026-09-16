using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    public class MedicoService
    {
        //cRIAND UM OJETO DO TIPO APPDBCONTEXT
        private readonly AppDbContext _context;

        //Injetando dependencia
        public MedicoService(AppDbContext context)
        { 
            
            _context = context;
            

        }

        public List<Medico> Listar() 
        {

            return _context.Medicos.ToList();   
        }

        public void Inserir(Medico obj)
        {
            _context.Medicos.Add(obj);
            _context.SaveChanges();

        }

    }
}
