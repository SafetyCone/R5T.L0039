using System;


namespace R5T.L0039.O001
{
    public class ProjectContextConstructors : IProjectContextConstructors
    {
        #region Infrastructure

        public static IProjectContextConstructors Instance { get; } = new ProjectContextConstructors();


        private ProjectContextConstructors()
        {
        }

        #endregion
    }
}
