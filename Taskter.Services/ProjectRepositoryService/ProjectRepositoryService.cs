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
        /// Concrete Implementation of <see cref="IProjectRepositoryService.GetLatestStoryNumberForProject(string)">
        /// </summary>
        public string GetLatestStoryNumberForProject(string ProjectAcronym)
        {
            var result = _projectRepository.GetLatestStoryNumberForProject(ProjectAcronym);

            if (string.IsNullOrWhiteSpace(result)) 
            {
                var projectAcronym = CreateProjectAcronym(ProjectAcronym);

                if (ProjectAcronym.Equals(projectAcronym))
                    return "1";
            }

            return result;
        }

        /// <summary>
        /// Concrete Implementation of <see cref="IProjectRepositoryService.CreateProjectAcronym(string)">
        /// </summary>
        public string CreateProjectAcronym(string ProjectAcronym)
        {
            _projectRepository.CreateProjectAcronym(ProjectAcronym);

            var result = _projectRepository.GetLatestStoryNumberForProject(ProjectAcronym);
            if (result != null) 
            {
                return ProjectAcronym;
            }

            return string.Empty;
        }

        /// <summary>
        /// Concrete Implementation of <see cref="IProjectRepositoryService.UpdateLatestStoryNumberForProject(string)">
        /// </summary>
        public string UpdateLatestStoryNumberForProject(string ProjectAcronym)
        {
            // makes sure that the project exists before updating.
            var _ = GetLatestStoryNumberForProject(ProjectAcronym);
            _projectRepository.UpdateLatestStoryNumberForProject(ProjectAcronym);

            var result = _projectRepository.GetLatestStoryNumberForProject(ProjectAcronym);

            if (result != null)
            {
                return result;
            }

            return string.Empty;
        }

    }
}
