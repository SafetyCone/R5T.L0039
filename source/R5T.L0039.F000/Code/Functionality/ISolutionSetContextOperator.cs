using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;

using R5T.L0039.T000;


namespace R5T.L0039.F000
{
    [FunctionalityMarker]
    public partial interface ISolutionSetContextOperator : IFunctionalityMarker
    {
        public Task In_SolutionSetContext(
            ITextOutput textOutput,
            IEnumerable<Func<ISolutionSetContext, Task>> operations)
        {
            return Instances.ContextOperator.In_Context(
                () => new SolutionSetContext
                {
                    TextOutput = textOutput,
                },
                operations,
                Instances.ActionOperations.DoNothing_Synchronous);
        }

        public Task In_SolutionSetContext(
            ITextOutput textOutput,
            params Func<ISolutionSetContext, Task>[] operations)
        {
            return this.In_SolutionSetContext(
                textOutput,
                operations.AsEnumerable());
        }
    }
}
