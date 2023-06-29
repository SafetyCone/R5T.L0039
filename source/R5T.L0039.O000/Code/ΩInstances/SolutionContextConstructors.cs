using System;


namespace R5T.L0039.O000
{
    public class SolutionContextConstructors : ISolutionContextConstructors
    {
        #region Infrastructure

        public static ISolutionContextConstructors Instance { get; } = new SolutionContextConstructors();


        private SolutionContextConstructors()
        {
        }

        #endregion
    }
}
