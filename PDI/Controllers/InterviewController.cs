using Microsoft.AspNetCore.Mvc;
using PDI.DTO;
using PDI.Repository.Interface;

namespace PDI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewRepository _repository;

        public InterviewController(IInterviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var interviews = await _repository.GetAllInterviews();
            return Ok(interviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interview = await _repository.GetInterviewById(id);
            if (interview == null) return NotFound();
            return Ok(interview);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Interview interview)
        {
            var created = await _repository.AddInterview(interview);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Interview interview)
        {
            var updated = await _repository.UpdateInterview(id, interview);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteInterview(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
