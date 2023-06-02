using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0172;


namespace R5T.L0039.T000
{
    /// <inheritdoc cref="ISolutionDirectoryContext"/>
    [ContextImplementationMarker]
    public class SolutionDirectoryContext : IContextImplementationMarker,
        ISolutionDirectoryContext
    {
        public ISolutionDirectoryPath SolutionDirectoryPath { get; set; }

        public ITextOutput TextOutput { get; set; }
    }
}