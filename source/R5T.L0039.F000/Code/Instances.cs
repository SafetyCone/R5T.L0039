using System;


namespace R5T.L0039.F000
{
    public static class Instances
    {
        public static F0000.IActionOperations ActionOperations => F0000.ActionOperations.Instance;
        public static L0031.IContextOperator ContextOperator => L0031.ContextOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0129.ISolutionPathsOperator SolutionPathsOperator => F0129.SolutionPathsOperator.Instance;
    }
}