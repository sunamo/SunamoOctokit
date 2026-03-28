namespace SunamoOctokit._sunamo.SunamoExceptions;

/// <summary>
/// Utility class for formatting exception messages.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// Converts an exception and optionally its inner exceptions into a formatted text message.
    /// </summary>
    /// <param name="exception">The exception to convert to text.</param>
    /// <param name="isIncludingInnerExceptions">When true, includes all inner exception messages in the output.</param>
    /// <returns>A formatted string containing the exception message(s).</returns>
    internal static string TextOfExceptions(Exception exception, bool isIncludingInnerExceptions = true)
    {
        if (exception == null) return string.Empty;
        StringBuilder stringBuilder = new();
        stringBuilder.Append("Exception:");
        stringBuilder.AppendLine(exception.Message);
        if (isIncludingInnerExceptions)
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                stringBuilder.AppendLine(exception.Message);
            }
        var result = stringBuilder.ToString();
        return result;
    }
}
