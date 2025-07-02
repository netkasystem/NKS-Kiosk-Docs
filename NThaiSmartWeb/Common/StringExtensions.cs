using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    private static readonly Regex PlaceholderRegex = new(@"\{(\w+)\}", RegexOptions.Compiled);

    public static string ReplaceByObject(this string input, JObject values)
    {
        if (string.IsNullOrEmpty(input) || values == null)
            return input;

        string result = PlaceholderRegex.Replace(input, match =>
        {
            string key = match.Groups[1].Value; // ดึง key ภายใน {...}
            var token = values.SelectToken(key, false); // หา key ใน JObject (ไม่ case-sensitive)

            // ถ้าพบ key และไม่ null ให้แทนที่ด้วยค่า string, ถ้าไม่เจอให้แทนที่เป็นค่าว่าง
            return token != null ? token.ToString() : "";
        });

        return result;
    }
}