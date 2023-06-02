using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0194;


namespace R5T.L0039.T000
{
    /// <summary>
    /// Solution directory context.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ISolutionDirectoryContext : IContextDefinitionMarker,
        ITextOutputtedContext
    {
        ISolutionDirectoryPath SolutionDirectoryPath { get; set; }
    }
}