using System;

using R5T.L0039.T000;
using R5T.T0131;
using R5T.T0159;
using R5T.T0172;
using R5T.T0180;
using R5T.T0187;


namespace R5T.L0039.O002
{
    [ValuesMarker]
    public partial interface ISolutionContextConstructors : IValuesMarker
    {
        Func<ISolutionContext> Get_SolutionContext(
            ISolutionName solutionName,
            ISolutionDirectoryPath solutionDirectoryPath,
            ITextOutput textOutput)
        {
            return () => Instances.SolutionContextConstructor.Get_SolutionContext(
                solutionName,
                solutionDirectoryPath,
                textOutput);
        }

        public Func<ISolutionContext> Get_SolutionContext(
            ISolutionName solutionName,
            // Use the base local repository directory path type.
            T0200.N001.ILocalRepositoryDirectoryPath repositoryDirectoryPath,
            ITextOutput textOutput)
        {
            return () => Instances.SolutionContextConstructor.Get_SolutionContext(
                solutionName,
                repositoryDirectoryPath,
                textOutput);
        }
    }
}
