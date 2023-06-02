using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0039.T000
{
    /// <inheritdoc cref="ISolutionSetContext"/>
    [ContextImplementationMarker]
    public class SolutionSetContext : IContextImplementationMarker,
        ISolutionSetContext
    {
        public ITextOutput TextOutput { get; set; }
    }
}