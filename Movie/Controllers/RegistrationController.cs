using Movie.DAL;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeRegistration(string firstname, string lastname, string email, string username, string password, string confirmpassword)
        {

            if (firstname == null || firstname == "")
            {
                TempData["RegistrationError"] = "Molimo Vas unesite ime!";
                return Redirect("/Registration");
            }

            if (lastname == null || lastname == "")
            {
                TempData["RegistrationError"] = "Molimo Vas unesite prezime";
                return Redirect("/Registration");
            }

            if (password == null || password == "")
            {
                TempData["RegistrationError"] = "Molimo Vas unesite lozinku";
                return Redirect("/Registration");
            }

            if (confirmpassword == null || confirmpassword == "")
            {
                TempData["RegistrationError"] = "Molimo Vas potvrdite lozinku";
                return Redirect("/Registration");
            }


            if (password != confirmpassword)
            {
                TempData["RegistrationError"] = "Potvrda lozinke nije tacna!";
                return Redirect("/Registration");
            }

            using (var dtx = new DataContext())
            {
                var checkUsername = dtx.Users.Where(item => item.UserName == username).Count();
                if (checkUsername > 0)
                {
                    TempData["RegistrationError"] = "Korisnicko ime je zauzeto!";
                    return Redirect("/Registration");
                }

                User newUser = new User();
                newUser.Name = firstname;
                newUser.LastName = lastname;
                newUser.UserName = username;
                newUser.Password = password;

                dtx.Users.Add(newUser);
                dtx.SaveChanges();

                TempData["RegistrationSuccess"] = "Uspjesno ste se registrovali!";
                return Redirect("/Registration");
            }
            return Redirect("/Registration");
        }


    }
}