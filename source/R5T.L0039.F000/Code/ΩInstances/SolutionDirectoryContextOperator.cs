using System;


namespace R5T.L0039.F000
{
    public class SolutionDirectoryContextOperator : ISolutionDirectoryContextOperator
    {
        #region Infrastructure

        public static ISolutionDirectoryContextOperator Instance { get; } = new SolutionDirectoryContextOperator();


        private SolutionDirectoryContextOperator()
        {
        }

        #endregion
    }
}
