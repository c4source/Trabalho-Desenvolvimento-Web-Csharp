using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;
using Agendamento.Models;

namespace Agendamento.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // LISTAR
        public IActionResult Index()
        {
            var listaPacientes = _pacienteService.Listar();

            return View(listaPacientes);
        }

        // ABRIR FORMULÁRIO DE INSERÇÃO
        public IActionResult Inserir()
        {
            return View();
        }

        // RECEBER FORMULÁRIO DE INSERÇÃO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return View(paciente);
            }

            _pacienteService.Inserir(paciente);

            return RedirectToAction(nameof(Index));
        }

        // ABRIR CONFIRMAÇÃO DE REMOÇÃO
        public IActionResult Remover(int id)
        {
            var paciente = _pacienteService.EncontrarId(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // CONFIRMAR REMOÇÃO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _pacienteService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}