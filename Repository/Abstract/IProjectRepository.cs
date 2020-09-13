namespace Taskter.Repository
{
    /// <summary>
    /// responsible for keeping latest story number for current story.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Gets the latest story number for the project.
        /// </summary>
        string GetLatestStoryNumberForProject(string ProjectAcronym);

        /// <summary>
        /// Updates the latest story number for the project.
        /// </summary>
        void UpdateLatestStoryNumberForProject(string ProjectAcronym);

        /// <summary>
        /// Creates a project in the repo for new sotires to be build against it.
        /// </summary>
        void CreateProjectAcronym(string ProjectAcronym);
    }
}
