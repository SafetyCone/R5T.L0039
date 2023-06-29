using System;


namespace R5T.L0039.O000
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F000.ISolutionContextOperator SolutionContextOperator => F000.SolutionContextOperator.Instance;
        public static Internal.ISolutionContextOperator SolutionContextOperator_Internal => Internal.SolutionContextOperator.Instance;
        public static F0024.ISolutionFileGenerator SolutionFileGenerator => F0024.SolutionFileGenerator.Instance;
        public static F0024.ISolutionOperator SolutionOperator => F0024.SolutionOperator.Instance;
        public static F0129.ISolutionPathsOperator SolutionPathsOperator => F0129.SolutionPathsOperator.Instance;
        public static F000.ISolutionSetContextOperator SolutionSetContextOperator => F000.SolutionSetContextOperator.Instance;
    }
}