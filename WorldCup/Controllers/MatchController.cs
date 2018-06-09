using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldCup.Service;
using WorldCup.Model;
using System.Net;

namespace WorldCup.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        private readonly MatchManager _matchesManager;
        private readonly TeamsManager _teamsManager;
        public MatchController()
        {
            _matchesManager = new MatchManager();
            _teamsManager = new TeamsManager();
        }
        [Authorize]
        public ActionResult Index()
        {

            return View(_matchesManager.ReturnAllMatches());
        }

        [Authorize]
        public ActionResult Create()
        {

            ViewBag.MatchTeams = _teamsManager.ReturnAllTeams().ToList();
            return View();
        }

       
        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KickOff,SelectedHomeTeamId,SelectedAwayTeamId")] MatchModel match)
        {
            if (ModelState.IsValid)
            {
                match.HomeTeam = _teamsManager.ReturnTeam(match.SelectedHomeTeamId);
                match.AwayTeam = _teamsManager.ReturnTeam(match.SelectedAwayTeamId);
                match.HomeTeamName = match.HomeTeam.Name;
                ViewBag.HomeTeamN = match.HomeTeam.Name;
                match.AwayTeamName = match.AwayTeam.Name;
                ViewBag.AwayTeamN = match.AwayTeam.Name;
                _matchesManager.CreateMatch(match);

                return RedirectToAction("Index");
            }

            return View(match);

        }
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MatchModel match = _matchesManager.ReturnMatch(id);

            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchModel match = _matchesManager.ReturnMatch(id);

            if (match == null)
            {
                return HttpNotFound();
            }
            match.HomeTeamName = ViewBag.HomeTeamN;
            match.AwayTeamName = ViewBag.AwayTeamN;
            ViewBag.MatchTeams = _teamsManager.ReturnAllTeams().ToList();
            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KickOff,SelectedHomeTeamId,SelectedAwayTeamId")] MatchModel match)
        {
            if (ModelState.IsValid)
            {
                
                    TeamModel Hometeam = _teamsManager.ReturnTeam(match.SelectedHomeTeamId);
                    match.HomeTeamName = Hometeam.Name;
                                
                    TeamModel Awayteam = _teamsManager.ReturnTeam(match.SelectedAwayTeamId);
                    match.AwayTeamName = Awayteam.Name;
                
                _matchesManager.UpdateMatch(match);
                return RedirectToAction("Index");
            }
            return View(match);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MatchModel match = _matchesManager.ReturnMatch(id);


            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _matchesManager.DeleteMatch(id);
            return RedirectToAction("Index");
        }

        
    }
}