using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0172;

using R5T.L0039.T000;


namespace R5T.L0039.O000.Internal
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker
    {
        public Task Set_SolutionDirectoryPath(
            ISolutionContext context,
            IHasSolutionDirectoryPath hasSolutionDirectoryPath)
        {
            var solutionDirectoryPath = Instances.SolutionPathsOperator.Get_SolutionDirectoryPath(
                context.SolutionFilePath);

            hasSolutionDirectoryPath.SolutionDirectoryPath = solutionDirectoryPath;

            return Task.CompletedTask;
        }

        public Task Set_SolutionFilePath(
            ISolutionContext context,
            IHasSolutionFilePath hasSolutionFilePath)
        {
            hasSolutionFilePath.SolutionFilePath = context.SolutionFilePath;

            return Task.CompletedTask;
        }
    }
}
