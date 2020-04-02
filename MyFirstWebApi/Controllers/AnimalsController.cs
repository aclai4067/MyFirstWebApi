using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
       static List<Animals> _animals = new List<Animals>
                                    { 
                                        new Animals { Id = 1, Name="Mark", Type= "Elephant", Weight= 1000 },
                                        new Animals { Id = 2, Name="Derek", Type= "Zebra", Weight= 500 },
                                        new Animals { Id = 3, Name="Murphy", Type= "Dog", Weight= 50 }
                                    };

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(_animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id) 
        {
            var selectedAnimal = _animals.FirstOrDefault(a => a.Id == id);

            if (selectedAnimal ==  null)
            {
                return NotFound($"Could not find an animal matching the id {id}");
            }
            return Ok(selectedAnimal);
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animals animalToAdd)
        {
            _animals.Add(animalToAdd);
            return Ok(_animals);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animals animal)
        {
            var animalToChange = _animals.FirstOrDefault(a => a.Id == id);
            if (animalToChange == null)
            {
                return NotFound("Cannot update; this animal does not exist");
            }

            animalToChange.Name = animal.Name;
            animalToChange.Weight = animal.Weight;
            animalToChange.Type = animal.Type;

            return Ok(animalToChange);
        }
    }
}