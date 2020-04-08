using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BTApp.Web.Models;
using AutoMapper;
using BTApp.BL;
using System;
using BTApp.Entities;

namespace BTApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordBL _passwordBL;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IPasswordBL passwordBL)
        {
            _logger = logger;
            _mapper = mapper;
            _passwordBL = passwordBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(UserPasswordDTO userPasswordDTO)
        {
            UserPassword userPassword = _passwordBL.GeneratePassword(_mapper.Map<UserPassword>(userPasswordDTO));
            UserPasswordDTO upDTO = _mapper.Map<UserPasswordDTO>(userPassword);
            return View("Validate", upDTO);
        }

        [HttpPost]
        public ActionResult ValidatePassword(UserPasswordDTO userPasswordDTO)
        {
            userPasswordDTO.IsValid = _passwordBL.CheckValidity(userPasswordDTO.UserID, userPasswordDTO.Password);
            return View("Index", userPasswordDTO);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
