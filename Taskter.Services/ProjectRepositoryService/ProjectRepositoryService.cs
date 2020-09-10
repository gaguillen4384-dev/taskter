using Taskter.Repository;

namespace Taskter.Services
{
    /// <summary>
    /// Concrete Implementation of <see cref="IProjectRepositoryService">
    /// </summary>
    public class ProjectRepositoryService : IProjectRepositoryService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectRepositoryService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// Concrete Implementation of <see cref="IProjectRepositoryService.InteractWithLatestStoryNumberForProject(string)">
        /// </summary>
        public string InteractWithLatestStoryNumberForProject(string ProjectAcronym)
        {
            throw new System.NotImplementedException();
        }
    }
}
