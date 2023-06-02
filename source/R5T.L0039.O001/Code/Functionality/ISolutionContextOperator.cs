using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0172;
using R5T.T0187;

using R5T.L0039.T000;


namespace R5T.L0039.O001
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker,
        O000.ISolutionContextOperator
    {
        /// <summary>
        /// Creates a new solution file.
        /// Because this is a 'new' method, it will throw an exception if the solution file already exists.
        /// </summary>
        public Task In_Create_New_SolutionContext(
            ISolutionFilePath solutionFilePath,
            ISolutionName solutionName,
            ITextOutput textOutput,
            params Func<ISolutionContext, Task>[] operations)
        {
            var modifiedOperations = operations
                .Prepend(
                    Instances.SolutionContextOperations.Create_New_SolutionFile)
                ;

            return this.In_New_SolutionContext(
                solutionFilePath,
                solutionName,
                textOutput,
                modifiedOperations);
        }
    }
}
