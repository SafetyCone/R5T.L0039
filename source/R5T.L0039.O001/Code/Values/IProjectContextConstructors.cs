using System;

using R5T.L0039.T000;
using R5T.T0131;
using R5T.T0187;

using R5T.L0040.T000;


namespace R5T.L0039.O001
{
    [ValuesMarker]
    public partial interface IProjectContextConstructors : IValuesMarker
    {
        public Func<ISolutionContext, IProjectContext> Default(
            IProjectName projectName)
        {
            return solutionContext =>
            {
                // Deal with the project directory path.
                var solutionDirectoryPath = Instances.SolutionPathsOperator.Get_SolutionDirectoryPath(solutionContext.SolutionFilePath);

                var projectContext = Instances.ProjectContextConstructor.Default(
                    projectName,
                    solutionDirectoryPath);

                return projectContext;
            };
        }
    }
}
