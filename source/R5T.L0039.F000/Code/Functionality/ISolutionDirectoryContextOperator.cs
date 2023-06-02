using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0172;

using R5T.L0039.T000;


namespace R5T.L0039.F000
{
    [FunctionalityMarker]
    public partial interface ISolutionDirectoryContextOperator : IFunctionalityMarker
    {
        public Task In_SolutionDirectoryContext(
            ISolutionDirectoryPath solutionDirectoryPath,
            ITextOutput textOutput,
            IEnumerable<Func<ISolutionDirectoryContext, Task>> operations)
        {
            return Instances.ContextOperator.In_Context(
                () => new SolutionDirectoryContext
                {
                    SolutionDirectoryPath = solutionDirectoryPath,
                    TextOutput = textOutput,
                },
                operations,
                Instances.ActionOperations.DoNothing_Synchronous);
        }

        public Task In_SolutionDirectoryContext(
            ISolutionDirectoryPath solutionDirectoryPath,
            ITextOutput textOutput,
            params Func<ISolutionDirectoryContext, Task>[] operations)
        {
            return this.In_SolutionDirectoryContext(
                solutionDirectoryPath,
                textOutput,
                operations.AsEnumerable());
        }
    }
}
