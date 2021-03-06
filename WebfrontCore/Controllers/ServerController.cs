﻿using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebfrontCore.Controllers
{
    public class ServerController : Controller
    {
 
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult  ClientActivity(int id)
        {

            var s = IW4MAdmin.Program.ServerManager.GetServers().FirstOrDefault(s2 => s2.GetHashCode() == id);
            if (s == null)
                return View("Error", "Invalid server!");

            var serverInfo = new ServerInfo()
            {
                Name = s.Hostname,
                ID = s.GetHashCode(),
                Port = s.GetPort(),
                Map = s.CurrentMap.Alias,
                ClientCount = s.ClientNum,
                MaxClients = s.MaxClients,
                GameType = s.Gametype,
                Players = s.Players.Where(p => p != null).Select(p => new PlayerInfo
                {
                    Name = p.Name,
                    ClientId = p.ClientId
                }).ToList(),
                ChatHistory = s.ChatHistory.OrderBy(c => c.Time).Take((int)Math.Ceiling(s.ClientNum / 2.0)).ToArray(),
                PlayerHistory = s.PlayerHistory.ToArray()
            };
            return PartialView("_ClientActivity", serverInfo);
        }
    }
}
