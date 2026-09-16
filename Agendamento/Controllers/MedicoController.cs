using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class MedicoController : Controller  
    {


        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService) {

            _medicoService = medicoService;
        }


        //var temporario = MedicoService.Listar();

        public IActionResult Index() 
        {
            var LisTaMedicos = _medicoService.Listar();
            return View(LisTaMedicos);


        }

        public IActionResult Inserir() 
        { 
                
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(Medico m) 
        {

            if (!ModelState.IsValid) 
            {

                return View(m);
            
            }


            _medicoService.Inserir(m);
            return RedirectToAction(nameof(Index));
        
        }


    }
}
