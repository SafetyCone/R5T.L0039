using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0039.T000
{
    /// <inheritdoc cref="ISolutionContext"/>
    [ContextImplementationMarker]
    public class SolutionContext : IContextImplementationMarker,
        ISolutionContext
    {
        public ISolutionFilePath SolutionFilePath { get; set; }
        public ISolutionName SolutionName { get; set; }

        public ITextOutput TextOutput { get; set; }
    }
}