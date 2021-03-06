﻿using System.Net;
using System.Web.Mvc;
using ClientManagement.Core.Models;
using ClientManagement.Core.Services;

namespace ClientManagement.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: Client
        public ActionResult Index()
        {
            var clients = _clientService.GetAllClients();
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _clientService.GetClient(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult ClientProjects(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projects = _clientService.GetClientProjects(id.Value);
            ViewBag.ClientName = _clientService.GetClient(id.Value).Name;
            return View(projects);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmailAddress")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.SaveClient(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _clientService.GetClient(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmailAddress")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.SaveClient(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _clientService.GetClient(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clientService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
