using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0187;
using R5T.T0194;


namespace R5T.L0039.T000
{
    /// <summary>
    /// Visual Studio solution context.
    /// </summary>
    [ContextTypeMarker]
    public interface ISolutionContext : IContextDefinitionMarker,
        ITextOutputtedContext
    {
        public ISolutionName SolutionName { get; }
        public ISolutionFilePath SolutionFilePath { get; }
    }
}