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
        string InteractWithLatestStoryNumberForProject(string ProjectAcronym);
    }
}
