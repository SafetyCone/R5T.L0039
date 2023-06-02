using System;


namespace R5T.L0039.O000
{
    public class SolutionDirectoryContextOperations : ISolutionDirectoryContextOperations
    {
        #region Infrastructure

        public static ISolutionDirectoryContextOperations Instance { get; } = new SolutionDirectoryContextOperations();


        private SolutionDirectoryContextOperations()
        {
        }

        #endregion
    }
}
