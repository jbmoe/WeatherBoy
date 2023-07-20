namespace WeatherBoy.Component.WeatherApi.Domain.Helpers;

public static class LetterSubstituteHelper
{
    public static string ReplaceDanoLetters(string text)
    {
        var replacements = new Dictionary<string, string>
        {
            { "æ", "ae" },
            { "ø", "oe" },
            { "å", "aa" },
            { "Æ", "Ae" },
            { "Ø", "Oe" },
            { "Å", "Aa" },
        };

        return replacements.Aggregate(text, (current, entry) => current.Replace(entry.Key, entry.Value));
    }
}