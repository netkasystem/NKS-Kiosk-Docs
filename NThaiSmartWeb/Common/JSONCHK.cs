using Newtonsoft.Json.Linq;

public static class JSONCHK
{
    public static bool IsJson(this string _str) { try { JToken.Parse(_str); return true; } catch { return false; } }
    public static string GetSQLWhere(this JObject model, string _column, string _token_val)
    {
        var _token = model.SelectToken(_token_val);
        if (_token != null)
        {
            string _type = _token.Type.ToString() ?? "";
            if (_type == "Array")
            {
                if (_token.Where(x => !string.IsNullOrEmpty(x.ToString())).Any())
                    return $" and {_column} in ({string.Join(",", _token.ToList())})";
            }
            else if (_type == "String" || _type == "Integer")
            {
                var _value = _token.ToString();
                if (!string.IsNullOrEmpty(_value) && _value != "-1")
                    return $" and {_column} = {_value}";
            }
        }
        return "";
    }
}