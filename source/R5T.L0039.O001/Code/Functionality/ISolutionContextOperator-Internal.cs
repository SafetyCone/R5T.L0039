using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0040.T000;
using R5T.T0132;
using R5T.T0187;

using R5T.L0039.T000;


namespace R5T.L0039.O001.Internal
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Creates the project directory, but not the project file.
        /// Because this is the 'new' method, it throws an exception if the project directory already exists.
        /// </summary>
        public Task In_New_ProjectContext(
            ISolutionContext solutionContext,
            IProjectName projectName,
            IEnumerable<Func<IProjectContext, Task>> operations)
        {
            // Deal with the project directory path.
            var solutionDirectoryPath = Instances.SolutionPathsOperator.Get_SolutionDirectoryPath(solutionContext.SolutionFilePath);

            var projectFilePath = Instances.ProjectPathConventions.Get_ProjectFilePath(
                solutionDirectoryPath,
                projectName);

            var projectDirectoryPath = Instances.ProjectPathsOperator.Get_ProjectDirectoryPath(projectFilePath);

            Instances.FileSystemOperator.Verify_DirectoryDoesNotExists(projectDirectoryPath.Value);

            Instances.FileSystemOperator.CreateDirectory(projectDirectoryPath.Value);

            var projectContext = new ProjectContext
            {
                ProjectName = projectName,
                ProjectFilePath = projectFilePath,
            };

            return Instances.ActionOperator.Run(
                projectContext,
                operations);
        }

        /// <inheritdoc cref="In_New_ProjectContext(ISolutionContext, IProjectName, Func{IProjectContext, Task}[])"/>
        public Task In_New_ProjectContext(
            ISolutionContext solutionContext,
            IProjectName projectName,
            params Func<IProjectContext, Task>[] operations)
        {
            return this.In_New_ProjectContext(
                solutionContext,
                projectName,
                operations.AsEnumerable());
        }
    }
}
