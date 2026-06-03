using System.ComponentModel;
using System.Threading;
using Frends.Acme.StringConcat.Models;

namespace Frends.Acme.StringConcat;

public static partial class Tasks
{
    /// <summary>
    /// Concatenates an ordered list of strings, optionally joined by a separator.
    /// Null entries in the input array are treated as empty strings.
    /// </summary>
    /// <param name="input">Input parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Result object with the concatenated string on <see cref="Result.Output"/>.</returns>
    public static Result Concat(
        [PropertyTab] Input input,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var strings = input.Strings ?? System.Array.Empty<string>();
        var separator = input.Separator ?? string.Empty;

        var output = string.Join(separator, System.Linq.Enumerable.Select(strings, s => s ?? string.Empty));

        return new Result { Output = output };
    }
}
