using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Acme.StringConcat.Models;

/// <summary>
/// Input parameters for <see cref="Tasks.Concat"/>.
/// </summary>
public class Input
{
    /// <summary>
    /// Strings to concatenate, in order. Null entries are treated as empty strings.
    /// </summary>
    /// <example>new[] { "foo", "bar", "baz" }</example>
    [Required]
    [DisplayFormat(DataFormatString = "Expression")]
    public string[] Strings { get; init; } = System.Array.Empty<string>();

    /// <summary>
    /// Separator placed between each string. Defaults to a comma.
    /// </summary>
    /// <example>", "</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("\",\"")]
    public string Separator { get; init; } = string.Empty;
}

/// <summary>
/// Result of <see cref="Tasks.Concat"/>.
/// </summary>
public class Result
{
    /// <summary>
    /// The concatenated string.
    /// </summary>
    /// <example>"foo, bar, baz"</example>
    public string Output { get; init; } = string.Empty;
}
