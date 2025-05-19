using Microsoft.EntityFrameworkCore;
using PDI.Data;
using PDI.DTO;
using PDI.Repository.Interface;

namespace PDI.Repository.Implentation
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly ApplicationDbContext _context;

        public InterviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Interview> AddInterview(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();
            return interview;
        }

        public async Task<IEnumerable<Interview>> GetAllInterviews()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task<Interview?> GetInterviewById(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }

        public async Task<Interview?> UpdateInterview(int id, Interview interview)
        {
            var existing = await _context.Interviews.FindAsync(id);
            if (existing == null) return null;

            existing.CompanyName = interview.CompanyName;
            existing.HrName = interview.HrName;
            existing.HrEmail = interview.HrEmail;
            existing.Position = interview.Position;
            existing.InterviewDate = interview.InterviewDate;
            existing.Status = interview.Status;
            existing.Notes = interview.Notes;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteInterview(int id)
        {
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null) return false;

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
