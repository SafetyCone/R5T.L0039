using System;


namespace R5T.L0039
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static ISolutionContextOperator SolutionContextOperator => L0039.SolutionContextOperator.Instance;
        public static F0129.ISolutionFileNameOperator SolutionFileNameOperator => F0129.SolutionFileNameOperator.Instance;
        public static F0129.ISolutionPathsOperator SolutionPathsOperator => F0129.SolutionPathsOperator.Instance;
    }
}