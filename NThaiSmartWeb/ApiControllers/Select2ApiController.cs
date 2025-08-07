using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NThaiSmartWeb.EFModels;

[ApiController]
[Route("api/[controller]")]
public class Select2ApiController : ControllerBase
{
    private readonly KioskContext _context;

    public Select2ApiController(KioskContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetKioskArea([FromQuery] string term = "", [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = _context.Kiosk.Where(k => string.IsNullOrEmpty(term) || k.Description.Contains(term)).OrderBy(k => k.Id);
        var totalCount = await query.CountAsync();
        var results = await query.Skip((page - 1) * pageSize).Take(pageSize).Select(k => new { id = k.Id, text = k.Description }).ToListAsync();

        return Ok(new
        {
            results,
            pagination = new
            {
                more = (page * pageSize) < totalCount
            }
        });
    }

    [HttpPost]
    [Route("SearchData")]
    public async Task<IActionResult> SearchData([FromBody] JObject model)
    {
        var result = await GetDetailSelect2(model);
        return Ok(result);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<object> GetDetailSelect2(JObject model_obj)
    {
        Select2Model model = model_obj.ToObject<Select2Model>();
        var items = new JArray();
        int total_count = 0;
        if (string.IsNullOrEmpty(model?.Select2Name)) BadRequest("FindDetailType not found!");
        var find_select2 = await _context.ExecuteSQL($"select * from select2_mapping where name = '{model.Select2Name}'");
        if (find_select2.Rows.Count > 0)
        {
            var list_filter = new List<string>();
            var select2_map = JArray.Parse(JsonConvert.SerializeObject(find_select2)).First();
            var pk_key = select2_map.SelectToken("pk_key")?.ToString();
            var query_search = select2_map.SelectToken("query_search")?.ToString();
            var query_where = select2_map.SelectToken("query_where")?.ToString() ?? " where 1=1 ";
            var query_group = select2_map.SelectToken("query_group")?.ToString() ?? "";
            var query_count = select2_map.SelectToken("query_count")?.ToString() ?? "";
            var query_order_by = select2_map.SelectToken("query_order_by")?.ToString() ?? "";
            var query_limit = model.length > 0 ? $" limit {model.length} " : "";
            var query_offset = model.start > 0 ? $" offset {model.start} " : "";

            var search = model.search?.value?.ToLower() ?? "";

            var _filter = select2_map.SelectToken("filter")?.ToString();
            if (_filter.IsJson())
            {
                var _JCon = JToken.Parse(_filter);
                var props1 = JToken.FromObject(_JCon);
                foreach (JProperty prop in props1)
                {
                    var _compare = props1[prop.Name].ToList();
                    _compare.ForEach(_c =>
                    {
                        if (model.Filter.SelectToken(_c.ToString()) != null)
                        {
                            model.Filter[prop.Name] = model.Filter.SelectToken(_c.ToString());
                        }
                        query_where += model.Filter.GetSQLWhere(prop.Name, _c.ToString());
                    });
                }
            }
            else
            {
                //filter is string
                list_filter = _filter?.Split(",")?.ToList() ?? new List<string>();
                list_filter = list_filter.Where(x => !string.IsNullOrEmpty(x)).ToList();
                list_filter.ForEach(_c =>
                {
                    query_where += model.Filter?.GetSQLWhere(_c, _c.ToString());
                });
            }

            if (model.Filter == null) model.Filter = new JObject();
            model.Filter["_search"] = search?.Trim();
            model.Filter.SmartAddObject(query_search, query_where, query_order_by);
            query_search = query_search.ReplaceByObject(model.Filter);
            query_where = query_where.ReplaceByObject(model.Filter);
            query_order_by = query_order_by.ReplaceByObject(model.Filter);

            var SetFirst = model_obj.SelectToken("SetFirst");
            if (SetFirst != null)
            {
                var SetFirstVal = JObject.FromObject(SetFirst);
                string Key = string.IsNullOrEmpty(pk_key) ? SetFirstVal.Properties()?.FirstOrDefault()?.Name ?? "" : pk_key;
                var Value = SetFirstVal.SelectToken(Key)?.ToString();
                query_where += SetFirstVal.GetSQLWhere(Key, Key);
            }

            var sql_count = $"select count(*) from ({query_search} {query_where} {query_group}) c";
            if (!string.IsNullOrEmpty(query_count)) sql_count = $"{query_count} {query_where}";
            var result = await _context.SelectExecuteCommand(sql_count);
            total_count = int.Parse(result?.ToString() ?? "0");

            var select2_detail = await _context.ExecuteSQL($"{query_search} {query_where} {query_group} {query_order_by} {query_limit} {query_offset}");
            items = JArray.Parse(JsonConvert.SerializeObject(select2_detail));
        }

        return new { items, total_count };
    }
}