using PDI.DTO;

namespace PDI.Repository.Interface
{
    public interface IInterviewRepository
    {
        Task<Interview> AddInterview(Interview interview);
        Task<IEnumerable<Interview>> GetAllInterviews();
        Task<Interview?> GetInterviewById(int id);
        Task<Interview?> UpdateInterview(int id, Interview interview);
        Task<bool> DeleteInterview(int id);
    }
}
