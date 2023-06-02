using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0187;

using R5T.L0039.T000;


namespace R5T.L0039.O000
{
    [ValuesMarker]
    public partial interface ISolutionDirectoryContextOperations : IValuesMarker
    {
        public Func<ISolutionDirectoryContext, Task> In_SolutionContext(
            ISolutionName solutionName,
            IEnumerable<Func<ISolutionContext, Task>> operations)
        {
            return solutionDirectoryContext =>
            {
                var solutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                    solutionDirectoryContext.SolutionDirectoryPath,
                    solutionName);

                return Instances.SolutionContextOperator.In_SolutionContext(
                    solutionFilePath,
                    solutionName,
                    solutionDirectoryContext.TextOutput,
                    operations);
            };
        }

        public Func<ISolutionDirectoryContext, Task> In_SolutionContext(
            ISolutionName solutionName,
            params Func<ISolutionContext, Task>[] operations)
        {
            return this.In_SolutionContext(
                solutionName,
                operations.AsEnumerable());
        }

        public Func<ISolutionDirectoryContext, Task> In_SolutionSetContext(
            IEnumerable<Func<ISolutionSetContext, Task>> operations)
        {
            return solutionDirectoryContext =>
            {
                return Instances.SolutionSetContextOperator.In_SolutionSetContext(
                    solutionDirectoryContext.TextOutput,
                    operations);
            };
        }

        public Func<ISolutionDirectoryContext, Task> In_SolutionSetContext(
            params Func<ISolutionSetContext, Task>[] operations)
        {
            return this.In_SolutionSetContext(
                operations.AsEnumerable());
        }
    }
}
