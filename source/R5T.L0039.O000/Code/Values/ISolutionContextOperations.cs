using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0172;

using R5T.L0039.T000;


namespace R5T.L0039.O000
{
    [ValuesMarker]
    public partial interface ISolutionContextOperations : IValuesMarker
    {
        /// <summary>
        /// Because this is the 'new' method, it will throw an exception if the solution file already exists.
        /// </summary>
        public Task Create_New_SolutionFile(ISolutionContext solutionContext)
        {
            Instances.FileSystemOperator.VerifyFileDoesNotExists(
                solutionContext.SolutionFilePath.Value);

            Instances.SolutionFileGenerator.Create_New(
                solutionContext.SolutionFilePath.Value);

            return Task.CompletedTask;
        }

        public Func<ISolutionContext, Task> Set_DefaultStartupProject(Func<IProjectFilePath> defaultStartupProjectFilePathProvider)
            => context =>
            {
                var defaultStartupProjectFilePath = defaultStartupProjectFilePathProvider();

                Instances.SolutionOperator.Set_DefaultStartupProject(
                    context.SolutionFilePath.Value,
                    defaultStartupProjectFilePath.Value);

                return Task.CompletedTask;
            };

        public Func<ISolutionContext, Task> Set_SolutionDirectoryPath(IHasSolutionDirectoryPath hasSolutionDirectoryPath)
            => context => Instances.SolutionContextOperator_Internal.Set_SolutionDirectoryPath(
                context,
                hasSolutionDirectoryPath);

        public Func<ISolutionContext, Task> Set_SolutionFilePath(IHasSolutionFilePath hasSolutionFilePath)
            => context => Instances.SolutionContextOperator_Internal.Set_SolutionFilePath(
                context,
                hasSolutionFilePath);
    }
}
