using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestProject.Context;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KullanicilarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kullanıcının bilgilerini listeler .
        public async Task<IActionResult> Index()
        {
            return _context.Kullanicilar != null ?
                        View(await _context.Kullanicilar.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Kullanicilar'  is null.");
        }

        // GET: Kullanicilar/Details/5 Verilen id'li kullanıcıyı görüntüler.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var customer = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Kullanicilar/Create Yeni bir kullanıcı oluşturma formunu getirir.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanicilar/Create Get metoduyla getirilen formun doldurulmuş halini gönderen  POST metodu.
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,UserName,Password,EmaillAddress,PhoneNumber")] Kullanici customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Kullanicilar/Edit/5 ID ile istenilen kullanıcının bilgilerinin düzenlenmesini sağlayan get metodu.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var customer = await _context.Kullanicilar.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Kullanicilar/Edit/5 Bu metodla editlediğimiz kullanıcının bikgilerini tekrar veri tabanına gönderiyoruz.
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,UserName,Password,EmaillAddress,PhoneNumber")] Kullanici customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Kullanicilar/Delete/5 silmek istediğimiz {0} ID'li kullanıcının bilgilerini gösteren sayfayı getirir.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var customer = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Kullanicilar/Delete/5 ID'li kullanıcı bilgilerini silmek icin kullanılır.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanicilar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kullanicilar'  is null.");
            }
            var customer = await _context.Kullanicilar.FindAsync(id);
            if (customer != null)
            {
                _context.Kullanicilar.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return (_context.Kullanicilar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
