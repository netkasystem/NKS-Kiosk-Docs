using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

//Start - Class sent from Datatables

public class DataTableAjaxPostViewModel
{
    [Ignore]
    public int draw { get; set; }

    [Ignore]
    public int start { get; set; }

    [Ignore]
    public int length { get; set; }

    [Ignore]
    public int recordsTotal { get; set; }

    [Ignore]
    public int recordsFiltered { get; set; }

    [Ignore]
    public List<Column> columns { get; set; }

    [Ignore]
    public Search search { get; set; }

    [Ignore]
    public List<Order> order { get; set; }

    [Ignore]
    public JObject AdvanceFilter { get; set; }
}

public class Column
{
    public string data { get; set; }
    public string name { get; set; }
    public bool searchable { get; set; }
    public bool orderable { get; set; }
    public Search search { get; set; }
}

public class Filter
{
    [Ignore]
    public string value { get; set; }

    [Ignore]
    public string filterby { get; set; }
}

public class Search
{
    [Ignore]
    [DefaultValue("")]
    public string value { get; set; }

    [Ignore]
    public string regex { get; set; }

    [Ignore]
    public string searchby { get; set; }
}

public class Order
{
    public int column { get; set; }
    public string dir { get; set; }
}

/// End- Class sent from Datatables