using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldCup.Model;
using WorldCup.Service;

namespace WorldCup.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        private readonly TeamsManager _teamsManager;
        public TeamController()
        {
            _teamsManager = new TeamsManager();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(_teamsManager.ReturnAllTeams());
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeamModel team = _teamsManager.ReturnTeam(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, WCwins, WCappearances, Continent")] TeamModel team)
        {
            if (ModelState.IsValid)
            {
                _teamsManager.CreateTeam(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel team = _teamsManager.ReturnTeam(id);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, WCwins, WCappearances, Continent")] TeamModel team)
        {
            if (ModelState.IsValid)
            {
                _teamsManager.UpdateTeam(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TeamModel team = _teamsManager.ReturnTeam(id);


            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _teamsManager.DeleteTeam(id);
            return RedirectToAction("Index");
        }
    }
}