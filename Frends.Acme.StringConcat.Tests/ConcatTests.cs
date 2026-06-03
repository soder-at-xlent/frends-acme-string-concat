using System.Threading;
using Frends.Acme.StringConcat.Models;
using Shouldly;
using Xunit;

namespace Frends.Acme.StringConcat.Tests;

public class ConcatTests
{
    [Fact]
    public void Concatenates_strings_without_separator_by_default()
    {
        var input = new Input { Strings = new[] { "foo", "bar", "baz" } };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe("foobarbaz");
    }

    [Fact]
    public void Joins_strings_with_provided_separator()
    {
        var input = new Input
        {
            Strings = new[] { "foo", "bar", "baz" },
            Separator = ", ",
        };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe("foo, bar, baz");
    }

    [Fact]
    public void Returns_empty_string_for_empty_input_array()
    {
        var input = new Input { Strings = System.Array.Empty<string>() };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe(string.Empty);
    }

    [Fact]
    public void Returns_empty_string_when_strings_is_null()
    {
        var input = new Input { Strings = null! };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe(string.Empty);
    }

    [Fact]
    public void Treats_null_entries_as_empty_strings()
    {
        var input = new Input
        {
            Strings = new[] { "foo", null!, "baz" },
            Separator = "-",
        };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe("foo--baz");
    }

    [Fact]
    public void Returns_single_string_unchanged_when_only_one_element()
    {
        var input = new Input
        {
            Strings = new[] { "solo" },
            Separator = ", ",
        };

        var result = Tasks.Concat(input, CancellationToken.None);

        result.Output.ShouldBe("solo");
    }

    [Fact]
    public void Throws_when_cancellation_is_already_requested()
    {
        var input = new Input { Strings = new[] { "foo", "bar" } };
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        Should.Throw<System.OperationCanceledException>(
            () => Tasks.Concat(input, cts.Token));
    }
}
