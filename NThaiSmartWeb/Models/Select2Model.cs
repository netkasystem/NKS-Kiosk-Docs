using Newtonsoft.Json.Linq;

public class Select2Model : DataTableAjaxPostViewModel
{
    public string Select2Name { get; set; }
    public string TitleKey { get; set; }
    public JObject Filter { get; set; }
}
