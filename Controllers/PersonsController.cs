using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using People.Models.Services.Application;
using People.Models.ViewModels;
using People.Models.ViewModels.InputModels;

namespace People.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        /*  Creare un controller che recupera una lista di persone nell'action Index, 
        e i dettagli di una singola persona nell'action detail(int id)
        ad ogni persona può essere associata una lista di auto di cui la persona è proprietaria.
        Quindi nella pagina detail visualizzare oltre ai dettagli della persona, anche la lista di auto associate */
        public IActionResult Index()
        {
            ViewData["Title"] = "Lista di persone";
            List<PersonViewModel> people = personService.GetPeople();
            return View(people);
        }

        public IActionResult Detail(int id)
        {
            PersonDetailViewModel viewModel = personService.GetPerson(id);
            ViewData["Title"] = viewModel.Name;
            return View(viewModel);
        }

        public IActionResult Create(){
            ViewData["Title"] = "Nuova persona";
            var input = new PersonCreateInputModel();
            return View(input);
        }
        //etichetta
        [HttpPost]
        public IActionResult Create(PersonCreateInputModel input){
            ViewData["Title"] = "Nuova persona";
            PersonDetailViewModel person = personService.CreatePerson(input);
            return RedirectToAction(nameof(Index));
        }
    }
}