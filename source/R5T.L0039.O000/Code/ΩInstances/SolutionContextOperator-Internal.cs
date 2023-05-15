using System;


namespace R5T.L0039.O000.Internal
{
    public class SolutionContextOperator : ISolutionContextOperator
    {
        #region Infrastructure

        public static ISolutionContextOperator Instance { get; } = new SolutionContextOperator();


        private SolutionContextOperator()
        {
        }

        #endregion
    }
}
