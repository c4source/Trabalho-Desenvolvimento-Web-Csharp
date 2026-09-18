using System.Diagnostics;
using Agendamento.Data;
using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public IActionResult Index()
        {
            var listaMedicos = _medicoService.Listar();
            return View(listaMedicos);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Medico medico)
        {
            _medicoService.Inserir(medico);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _medicoService.EncontrarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _medicoService.EncontrarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Medico medico)
        {
            _medicoService.Atualizar(medico);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remover(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _medicoService.EncontrarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            _medicoService.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel);
        }
    }
}