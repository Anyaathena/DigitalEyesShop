using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EyesController : Controller
    {
        private eyesEntities db = new eyesEntities();

        // GET: Eyes
        public async Task<ActionResult> Index()
        {
            return View(await db.Eyes.ToListAsync());
        }

        // GET: Eyes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eye eye = await db.Eyes.FindAsync(id);
            if (eye == null)
            {
                return HttpNotFound();
            }
            return View(eye);
        }

        // GET: Eyes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eyes/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Account,RightEyeMyopia,RightEyeAstigmaticAngel,RightEyeAstigmatic,LeftEyeMyopia,LeftEyeAstigmaticAngel,LeftEyeAstigmatic,Price,FrameName,MyTime,Notes")] Eye eye)
        {
            if (ModelState.IsValid)
            {
                db.Eyes.Add(eye);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eye);
        }

        // GET: Eyes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eye eye = await db.Eyes.FindAsync(id);
            if (eye == null)
            {
                return HttpNotFound();
            }
            return View(eye);
        }

        // POST: Eyes/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Account,RightEyeMyopia,RightEyeAstigmaticAngel,RightEyeAstigmatic,LeftEyeMyopia,LeftEyeAstigmaticAngel,LeftEyeAstigmatic,Price,FrameName,MyTime,Notes")] Eye eye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eye).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eye);
        }

        // GET: Eyes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eye eye = await db.Eyes.FindAsync(id);
            if (eye == null)
            {
                return HttpNotFound();
            }
            return View(eye);
        }

        // POST: Eyes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Eye eye = await db.Eyes.FindAsync(id);
            db.Eyes.Remove(eye);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
