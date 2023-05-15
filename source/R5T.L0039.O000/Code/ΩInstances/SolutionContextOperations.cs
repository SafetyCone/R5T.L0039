using System;


namespace R5T.L0039.O000
{
    public class SolutionContextOperations : ISolutionContextOperations
    {
        #region Infrastructure

        public static ISolutionContextOperations Instance { get; } = new SolutionContextOperations();


        private SolutionContextOperations()
        {
        }

        #endregion
    }
}
