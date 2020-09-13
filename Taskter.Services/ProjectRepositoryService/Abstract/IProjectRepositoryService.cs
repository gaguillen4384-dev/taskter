namespace Taskter.Services
{
    /// <summary>
    /// Responsible for interfacing with the project repository object.
    /// </summary>
    public interface IProjectRepositoryService
    {
        /// <summary>
        /// Retrieves the latest story number for a project, and updates it aswell.
        /// </summary>
        string UpdateLatestStoryNumberForProject(string ProjectAcronym);


        /// <summary>
        /// Retrieves the latest story number for a project. Creates a project acronym if not found.
        /// </summary>
        string GetLatestStoryNumberForProject(string ProjectAcronym);

        /// <summary>
        /// Creates project into the repo to start creating new stories with.
        /// </summary>
        string CreateProjectAcronym(string ProjectAcronym);
    }
}
