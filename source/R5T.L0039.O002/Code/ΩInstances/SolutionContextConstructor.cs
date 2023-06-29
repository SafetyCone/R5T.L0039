using System;


namespace R5T.L0039.O002
{
    public class SolutionContextConstructor : ISolutionContextConstructor
    {
        #region Infrastructure

        public static ISolutionContextConstructor Instance { get; } = new SolutionContextConstructor();


        private SolutionContextConstructor()
        {
        }

        #endregion
    }
}
