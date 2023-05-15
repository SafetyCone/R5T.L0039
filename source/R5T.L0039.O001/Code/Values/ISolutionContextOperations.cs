using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0031.Extensions;
using R5T.L0033.T000;
using R5T.L0040.T000;
using R5T.T0131;
using R5T.T0172;
using R5T.T0187;

using R5T.L0039.T000;


namespace R5T.L0039.O001
{
    [ValuesMarker]
    public partial interface ISolutionContextOperations : IValuesMarker,
        O000.ISolutionContextOperations
    {
        /// <inheritdoc cref="Internal.ISolutionContextOperator.In_New_ProjectContext(ISolutionContext, IProjectName, Func{IProjectContext, Task}[])"/>
        public Func<ISolutionContext, Task> In_New_ProjectContext(
            IProjectName projectName,
            params Func<IProjectContext, Task>[] operations)
        {
            return context => Instances.SolutionContextOperator_Internal.In_New_ProjectContext(
                context,
                projectName,
                operations);
        }

        /// <inheritdoc cref="Internal.ISolutionContextOperator.In_New_ProjectContext(ISolutionContext, IProjectName, Func{IProjectContext, Task}[])"/>
        public Func<ISolutionContext, Task> In_New_ProjectContext(
            IProjectName projectName,
            IEnumerable<Func<IProjectContext, Task>> operations)
        {
            return context => Instances.SolutionContextOperator_Internal.In_New_ProjectContext(
                context,
                projectName,
                operations);
        }

        public Func<ISolutionContext, Task> In_Add_New_ProjectContext(
            IProjectName projectName,
            Func<IProjectFileContext, Task> createNewProjectFileOperation,
            Func<IProjectContext, Task> createNewProjectOperation,
            Func<IProjectFilePath, Task> projectFilePathHandler)
        {
            return solutionContext => solutionContext.Run(
                this.In_New_ProjectContext(
                    projectName,
                    Instances.ProjectContextOperations.In_New_ProjectFileContext(
                        createNewProjectFileOperation),
                    createNewProjectOperation,
                    projectContext => projectFilePathHandler(projectContext.ProjectFilePath),
                    Instances.ProjectContextOperations.Add_ToSolution(
                        solutionContext.SolutionFilePath)
                )
            );
        }

        /// <summary>
        /// Ensures the new project is added to the solution.
        /// Because this is a 'new' method, it will throw if the project directory already exists.
        /// </summary>
        public Func<ISolutionContext, Task> In_Add_New_ProjectContext(
            IProjectName projectName,
            bool addRecursiveProjectReferences,
            params Func<IProjectContext, Task>[] createProjectOperations)
        {
            return solutionContext => solutionContext.Run(
                this.In_New_ProjectContext(
                    projectName,
                    createProjectOperations
                        .Append(
                            Instances.ProjectContextOperations.Add_ToSolution(
                                solutionContext.SolutionFilePath,
                                addRecursiveProjectReferences)
                        )
                )
            );
        }

        /// <summary>
        /// Ensures the new project is added to the solution.
        /// Because this is a 'new' method, it will throw if the project directory already exists.
        /// </summary>
        public Func<ISolutionContext, Task> In_Add_New_ProjectContext(
            IProjectName projectName,
            params Func<IProjectContext, Task>[] createProjectOperations)
        {
            return this.In_Add_New_ProjectContext(
                projectName,
                true,
                createProjectOperations);
        }

        /// <summary>
        /// Because this is a 'new' method, it will throw an exception if the solution file already exists.
        /// </summary>
        public Func<ISolutionContext, Task> Create_New_Solution(
            Func<ISolutionFilePath, Task> solutionFilePathHandler,
            // No need for a solution file context operation (since the solution file is assumed to be simple).
            params Func<ISolutionContext, Task>[] createNewSolutionOperations)
        {
            var solutionContextOperations = new Func<ISolutionContext, Task>[]
            {
                // Create the solution file.
                this.Create_New_SolutionFile,
                // Handle the solution file path.
                solutionContext => solutionFilePathHandler(solutionContext.SolutionFilePath),
            }
            // Create the solution.
            .Append(createNewSolutionOperations);

            return solutionContext => solutionContext.Run(solutionContextOperations);
        }

        /// <inheritdoc cref="Create_New_Solution(Func{ISolutionFilePath, Task}, Func{ISolutionContext, Task}[])"/>
        public Func<ISolutionContext, Task> Create_New_Solution(
            IHasSolutionFilePath hasSolutionFilePath,
            // No need for a solution file context operation (since the solution file is assumed to be simple).
            params Func<ISolutionContext, Task>[] createNewSolutionOperations)
        {
            return this.Create_New_Solution(
                solutionFilePath =>
                {
                    hasSolutionFilePath.SolutionFilePath = solutionFilePath;

                    return Task.CompletedTask;
                },
                createNewSolutionOperations);
        }
    }
}
