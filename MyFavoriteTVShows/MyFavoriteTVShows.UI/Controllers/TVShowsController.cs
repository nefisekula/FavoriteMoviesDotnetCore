using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFavoriteTVShows.UI.Data;
using MyFavoriteTVShows.UI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyFavoriteTVShows.UI.Controllers
{
    public class TVShowsController : Controller
    {
        private readonly TVShowContext _context;

        public TVShowsController(TVShowContext context)
        {
            _context = context;
        }

        // GET: TVShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.TVShow.ToListAsync());
        }

        // GET: TVShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // GET: TVShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TVShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Rating,ImdbURL,ImageURL")] TVShow tVShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tVShow);
        }

        // GET: TVShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShow.FindAsync(id);
            if (tVShow == null)
            {
                return NotFound();
            }
            return View(tVShow);
        }

        // POST: TVShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Genre,Rating,ImdbURL,ImageURL")] TVShow tVShow)
        {
            if (id != tVShow.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVShowExists(tVShow.ID))
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
            return View(tVShow);
        }

        // GET: TVShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVShow = await _context.TVShow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tVShow == null)
            {
                return NotFound();
            }

            return View(tVShow);
        }

        // POST: TVShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tVShow = await _context.TVShow.FindAsync(id);
            _context.TVShow.Remove(tVShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVShowExists(int id)
        {
            return _context.TVShow.Any(e => e.ID == id);
        }
    }
}
