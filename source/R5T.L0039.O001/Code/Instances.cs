using System;


namespace R5T.L0039.O001
{
    public static class Instances
    {
        public static F0000.IActionOperator ActionOperator => F0000.ActionOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static L0040.IProjectContextOperations ProjectContextOperations => L0040.ProjectContextOperations.Instance;
        public static F0130.IProjectPathConventions ProjectPathConventions => F0130.ProjectPathConventions.Instance;
        public static F0129.IProjectPathsOperator ProjectPathsOperator => F0129.ProjectPathsOperator.Instance;
        public static Internal.ISolutionContextOperator SolutionContextOperator_Internal => Internal.SolutionContextOperator.Instance;
        public static F0024.ISolutionFileGenerator SolutionFileGenerator => F0024.SolutionFileGenerator.Instance;
        public static F0129.ISolutionPathsOperator SolutionPathsOperator => F0129.SolutionPathsOperator.Instance;
    }
}