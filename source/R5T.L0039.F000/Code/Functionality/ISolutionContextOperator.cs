using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187;

using R5T.L0039.T000;


namespace R5T.L0039.F000
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker
    {
        public async Task In_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            IEnumerable<Func<ISolutionContext, Task>> operations)
        {
            await Instances.ContextOperator.In_Context(
                () => new SolutionContext
                {
                    SolutionFilePath = solutionFilePath,
                    SolutionName = solutionName,
                    TextOutput = textOutput,
                },
                operations,
                Instances.ActionOperations.DoNothing_Synchronous);
        }

        public Task In_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            return this.In_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations.AsEnumerable());
        }

        /// <summary>
        /// Because this is a 'new' method, it will throw an exception if the solution file already exists.
        /// Note: does not create the solution file.
        /// </summary>
        public Task In_New_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            IEnumerable<Func<ISolutionContext, Task>> operations)
        {
            Instances.FileSystemOperator.Verify_File_DoesNotExist(
                solutionFilePath.Value);

            return this.In_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations);
        }


        public Task In_New_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            return this.In_New_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations.AsEnumerable());
        }

        /// <summary>
        /// Because this is a 'modify' method, it will throw an exception if the solution file does not exist.
        /// </summary>
        public Task In_Modify_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            Instances.FileSystemOperator.Verify_File_Exists(
                solutionFilePath.Value);

            return this.In_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations);
        }

        /// <summary>
        /// Because this is a 'modify' method, it will throw an exception if the solution file path does not exist.
        /// </summary>
        public Task In_Modify_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            var solutionName = Instances.SolutionPathsOperator.Get_SolutionName(solutionFilePath);

            return this.In_Modify_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations);
        }

        public Task In_SolutionContext(
            ISolutionDirectoryPath solutionDirectoryPath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            var solutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                solutionDirectoryPath,
                solutionName);

            return this.In_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                operations);
        }

        /// <summary>
        /// Creates the solution directory, but not the solution file path.
        /// Because this is a 'new' operation, it will throw an exception if the solution directory exists (unless the <paramref name="deleteSolutionDirectory_IfExists"/> is set to true).
        /// </summary>
        public async Task In_New_SolutionContext(
            ISolutionDirectoryPath solutionDirectoryPath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            bool deleteSolutionDirectory_IfExists = false,
            params Func<ISolutionContext, Task>[] createSolutionOperations)
        {
            // Deal with the solution directory.
            if (deleteSolutionDirectory_IfExists)
            {
                Instances.FileSystemOperator.Delete_Directory_Idempotent(
                    solutionDirectoryPath.Value);
            }

            Instances.FileSystemOperator.CreateDirectory(
                solutionDirectoryPath.Value);

            await this.In_SolutionContext(
                solutionDirectoryPath,
                solutionName,
                textOutput,
                createSolutionOperations);
        }
    }
}
