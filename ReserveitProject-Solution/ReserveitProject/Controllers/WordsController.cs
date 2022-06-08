using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReserveitProject.Interfaces;
using System.Collections.Generic;

namespace ReserveitProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;
        public WordsController(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        [HttpPost]
        public IActionResult PostWords([FromBody] string payload, [FromHeader] int pageSize)
        {
            bool isSaved = _wordsRepository.SaveWords(JsonConvert
                .DeserializeObject<List<string>>(payload), pageSize);
            if (isSaved)
                return StatusCode(201);
            else
                return StatusCode(400); //bad request
        }

        [HttpGet]
        public IActionResult GetLines()
        {
            var result = _wordsRepository.GetLines();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
