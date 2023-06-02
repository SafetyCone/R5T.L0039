using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0039.N001
{
    /// <inheritdoc cref="ISolutionContext"/>
    [ContextImplementationMarker]
    public class SolutionContext : IContextImplementationMarker,
        ISolutionContext
    {
        public ISolutionDirectoryPath DirectoryPath { get; set; }
        public ISolutionName SolutionName { get; set; }
    }
}
