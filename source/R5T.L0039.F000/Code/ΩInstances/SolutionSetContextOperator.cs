using System;


namespace R5T.L0039.F000
{
    public class SolutionSetContextOperator : ISolutionSetContextOperator
    {
        #region Infrastructure

        public static ISolutionSetContextOperator Instance { get; } = new SolutionSetContextOperator();


        private SolutionSetContextOperator()
        {
        }

        #endregion
    }
}
