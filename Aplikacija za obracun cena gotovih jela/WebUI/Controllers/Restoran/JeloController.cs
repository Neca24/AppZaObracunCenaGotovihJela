using Application.DTOs.JeloDTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers.Restoran
{
    public class JeloController : Controller
    {
        private readonly IJeloService _jeloService;
        private readonly IRecepturaService _recepturaService;
        private readonly IArtikalService _artikalService;

        public JeloController(IJeloService jeloService, IRecepturaService recepturaService, IArtikalService artikalService)
        {
            _jeloService = jeloService;
            _recepturaService = recepturaService;
            _artikalService = artikalService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _jeloService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new JeloDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JeloDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var id = await _jeloService.CreateAsync(dto);
            return RedirectToAction("EditReceptura", new { id });
        }

        public async Task<IActionResult> Details(int id)
        {
            var jelo = await _jeloService.GetByIdAsync(id);
            if (jelo == null) return NotFound();

            return View(jelo);
        }

        public async Task<IActionResult> EditReceptura(int id)
        {
            var model = new EditRecepturaViewModel();
            model.JeloId = id;

            model.Artikli = await _artikalService.GetAllAsync();
            model.PostojeceStavke = await _recepturaService.GetForJeloAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReceptura(EditRecepturaViewModel vm)
        {
            await _recepturaService.DodajStavku(vm.JeloId, vm.Stavke);
            return RedirectToAction("Details", new { id = vm.JeloId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _jeloService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
