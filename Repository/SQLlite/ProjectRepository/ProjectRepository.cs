using Microsoft.Data.Sqlite;

namespace Taskter.Repository
{
    /// <summary>
    /// Concrete implementation of <see cref="IProjectRepository">
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        /// <summary>
        /// Concrete implementation of <see cref="IProjectRepository.GetLatestStoryNumberForProject(string)">
        /// </summary>
        public string GetLatestStoryNumberForProject(string ProjectAcronym)
        {
            using (var connection = new SqliteConnection("Data Source=ProjectsNumber.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    SELECT LatestStoryNumber
                    FROM ProjectsNumbers
                    WHERE Project = $ProjectAcronym
                     ";
                command.Parameters.AddWithValue("$ProjectAcronym", ProjectAcronym);
                command.ExecuteNonQuery();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader["LatestStoryNumber"].ToString();
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Concrete implementation of <see cref="IProjectRepository.UpdateLatestStoryNumberForProject(string)">
        /// </summary>
        public void UpdateLatestStoryNumberForProject(string ProjectAcronym)
        {
            var storyNumber = GetLatestStoryNumberForProject(ProjectAcronym);
            var intStoryNumber = int.Parse(storyNumber);
            using (var connection = new SqliteConnection("Data Source=ProjectsNumber.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    UPDATE ProjectsNumbers
                    SET LatestStoryNumber = $StoryNumber
                    WHERE Project = $ProjectAcronym
                     ";
                command.Parameters.AddWithValue("$StoryNumber", intStoryNumber++);
                command.Parameters.AddWithValue("$ProjectAcronym", ProjectAcronym);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Concrete implementation of <see cref="IProjectRepository.CreateProjectAcronym(string)"> 
        /// </summary>
        public void CreateProjectAcronym(string ProjectAcronym)
        {
            using (var connection = new SqliteConnection("Data Source=ProjectsNumber.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    INSERT INTO [ProjectsNumbers]
                    ([Project]
                    ,[LatestStoryNumber])
                    VALUES
                    (
                    $ProjectAcronym,
                     $StoryNumber);

                     ";
                command.Parameters.AddWithValue("$ProjectAcronym", ProjectAcronym);
                command.Parameters.AddWithValue("$StoryNumber", 1);
                command.ExecuteNonQuery();
            }
        }
    }
}
