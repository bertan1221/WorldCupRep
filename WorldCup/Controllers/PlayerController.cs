using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldCup.Service;
using WorldCup.Model;


namespace WorldCup.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayersManager _playersManager;
        private readonly TeamsManager _teamsManager;
        public PlayerController()
        {
            _playersManager = new PlayersManager();
            _teamsManager = new TeamsManager();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(_playersManager.ReturnAllPlayers());
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlayerModel player = _playersManager.ReturnPlayer(id);

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }
        [Authorize]
        public ActionResult Create()
        {

            ViewBag.Teams = _teamsManager.ReturnAllTeams().ToList();
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,JerseyNumber,Position,WCappearances,WCgoalsScored,SelectedTeamId")] PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                player.Team = _teamsManager.ReturnTeam(player.SelectedTeamId);
                _playersManager.CreatePlayer(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel player = _playersManager.ReturnPlayer(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            player.SelectedTeamId = player.Team.Id;
            ViewBag.Teams = _teamsManager.ReturnAllTeams().ToList();
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,JerseyNumber,Position,WCappearances,WCgoalsScored,SelectedTeamId")] PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                _playersManager.UpdatePlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlayerModel player = _playersManager.ReturnPlayer(id);


            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _playersManager.DeletePlayer(id);
            return RedirectToAction("Index");
        }


    }
}