using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyMarketplace.Data;
using PropertyMarketplace.Models;

namespace PropertyMarketplace.Controllers
{
    public class AutoMotoesController : Controller
    {
        private readonly PropertyMarketplaceContext _context;

        public AutoMotoesController(PropertyMarketplaceContext context)
        {
            _context = context;
        }

        // GET: AutoMotoes
        public async Task<IActionResult> Index()
        {
            var propertyMarketplaceContext = _context.AutoMoto.Include(a => a.AdsBasicInfo).Include(a => a.AutoMotoModels).Include(a => a.Category).Include(a => a.Manufacturers);
            return View(await propertyMarketplaceContext.ToListAsync());
        }

        // GET: AutoMotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoMoto = await _context.AutoMoto
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers)
                .FirstOrDefaultAsync(m => m.AutoMotoID == id);
            if (autoMoto == null)
            {
                return NotFound();
            }

            return View(autoMoto);
        }

        // GET: AutoMotoes/Create
        public IActionResult Create()
        {
            ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID");
            ViewData["ModelID"] = new SelectList(_context.AutoMotoModels, "ModelID", "ModelID");
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerID");
            return View();
        }

        // POST: AutoMotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoMotoID,YearOfManufacture,Mileage,ManufacturerID,ModelID,TransmissionType,AdID,OwnerID,CategoryId")] AutoMoto autoMoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoMoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID", autoMoto.AdID);
            ViewData["ModelID"] = new SelectList(_context.AutoMotoModels, "ModelID", "ModelID", autoMoto.ModelID);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", autoMoto.CategoryId);
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerID", autoMoto.ManufacturerID);
            return View(autoMoto);
        }

        // GET: AutoMotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoMoto = await _context.AutoMoto.FindAsync(id);
            if (autoMoto == null)
            {
                return NotFound();
            }
            ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID", autoMoto.AdID);
            ViewData["ModelID"] = new SelectList(_context.AutoMotoModels, "ModelID", "ModelID", autoMoto.ModelID);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", autoMoto.CategoryId);
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerID", autoMoto.ManufacturerID);
            return View(autoMoto);
        }

        // POST: AutoMotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoMotoID,YearOfManufacture,Mileage,ManufacturerID,ModelID,TransmissionType,AdID,OwnerID,CategoryId")] AutoMoto autoMoto)
        {
            if (id != autoMoto.AutoMotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoMoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoMotoExists(autoMoto.AutoMotoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdID"] = new SelectList(_context.AdsBasicInfo, "AdID", "AdID", autoMoto.AdID);
            ViewData["ModelID"] = new SelectList(_context.AutoMotoModels, "ModelID", "ModelID", autoMoto.ModelID);
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", autoMoto.CategoryId);
            ViewData["ManufacturerID"] = new SelectList(_context.Manufacturers, "ManufacturerID", "ManufacturerID", autoMoto.ManufacturerID);
            return View(autoMoto);
        }

        // GET: AutoMotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoMoto = await _context.AutoMoto
                .Include(a => a.AdsBasicInfo)
                .Include(a => a.AutoMotoModels)
                .Include(a => a.Category)
                .Include(a => a.Manufacturers)
                .FirstOrDefaultAsync(m => m.AutoMotoID == id);
            if (autoMoto == null)
            {
                return NotFound();
            }

            return View(autoMoto);
        }

        // POST: AutoMotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoMoto = await _context.AutoMoto.FindAsync(id);
            _context.AutoMoto.Remove(autoMoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoMotoExists(int id)
        {
            return _context.AutoMoto.Any(e => e.AutoMotoID == id);
        }
    }
}
