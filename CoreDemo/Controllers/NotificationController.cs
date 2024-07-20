﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {

        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
