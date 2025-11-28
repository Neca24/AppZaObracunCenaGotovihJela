using Application.DTOs.ArtikalDTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebUI.Controllers.Restoran
{
    public class ArtikalController : Controller
    {
        private readonly IArtikalService _artikalService;

        public ArtikalController(IArtikalService artikalService)
        {
            _artikalService = artikalService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _artikalService.GetAllAsync();
            Console.WriteLine(model);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(nameof(Create),new ArtikalDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtikalDTO dto)
        {
            if (!ModelState.IsValid)
                return View(nameof(Create), dto);

            await _artikalService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _artikalService.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return View(nameof(Edit), dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ArtikalDTO dto)
        {
            if(!ModelState.IsValid)
                return View(nameof(Edit),dto);

            await _artikalService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _artikalService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
