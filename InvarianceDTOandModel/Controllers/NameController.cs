using Microsoft.AspNetCore.Mvc;
using System;
using ValidateTheNameModelBinding.DomainPrimitives;
using ValidateTheNameModelBinding.Models;
using ValidateTheNameModelBinding.Util;

namespace ValidateTheNameWebApplication.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new { nameIsValid = false, showNameEvaluation = false });
        }

        [HttpPost]
        public IActionResult ValidateName(PersonDTO person)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new {nameIsValid = false, showNameEvaluation = true, errorMessage = "Please Input Both Fields"});
            }

            //DI intentionally omittede here for clarity
            PersonRepository personRepository = new PersonRepository();

            try
            {
                Person personWithInvariance = new Person(
                    new FirstName(person.Firstname), 
                    new LastName(person.Lastname)
                    );

                personRepository.AddPerson(personWithInvariance);
            }
            catch (Exception exception)
            {
                return View("Index", new { nameIsValid = false, showNameEvaluation = true, errorMessage = exception.Message });

            }


            return View("Index", new { nameIsValid = true, showNameEvaluation = true });


        }

       
    }
}
