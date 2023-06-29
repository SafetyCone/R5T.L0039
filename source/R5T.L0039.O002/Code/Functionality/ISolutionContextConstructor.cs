using System;

using R5T.L0039.T000;
using R5T.T0132;
using R5T.T0159;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0180;
using R5T.T0187;


namespace R5T.L0039.O002
{
    [FunctionalityMarker]
    public partial interface ISolutionContextConstructor : IFunctionalityMarker
    {
        public ISolutionContext Get_SolutionContext(
            ISolutionName solutionName,
            ISolutionDirectoryPath solutionDirectoryPath,
            ITextOutput textOutput)
        {
            var solutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                solutionDirectoryPath,
                solutionName);

            // Now create and return the context.
            var output = new SolutionContext
            {
                SolutionName = solutionName,
                SolutionFilePath = solutionFilePath,
                TextOutput = textOutput,
            };

            return output;
        }

        public ISolutionContext Get_SolutionContext(
            ISolutionName solutionName,
            IDirectoryPath solutionDirectoryParentDirectoryPath,
            ITextOutput textOutput)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.Get_SolutionDirectoryPath(
                solutionDirectoryParentDirectoryPath,
                solutionName);

            return this.Get_SolutionContext(
                solutionName,
                solutionDirectoryPath,
                textOutput);
        }

        public ISolutionContext Get_SolutionContext(
            ISolutionName solutionName,
            // Use the base local repository directory path type.
            T0200.N001.ILocalRepositoryDirectoryPath repositoryDirectoryPath,
            ITextOutput textOutput)
        {
            var solutionDirectoryPath = Instances.RepositoryPathsOperator.GetSourceDirectoryPath(
                repositoryDirectoryPath.Value)
                .ToSolutionDirectoryPath();

            return this.Get_SolutionContext(
                solutionName,
                solutionDirectoryPath,
                textOutput);
        }
    }
}
