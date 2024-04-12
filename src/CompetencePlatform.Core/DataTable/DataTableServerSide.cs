using System.ComponentModel;

namespace CompetencePlatform.Core.DataTable
{
    public class DataTableServerSide
    {
        [DefaultValue(1)]
        public int Draw { get; set; }
        public List<Column> Columns { get; set; }
        public List<Order> Order { get; set; }
        [DefaultValue(1)]
        public int Start { get; set; }
        [DefaultValue(10)]
        public int Length { get; set; }
        public Search Search { get; set; }
        public int? Id { get; set; }
    }

    public class Column
    {
        public object Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public Search Search { get; set; }
    }

    public class Order
    {
        [DefaultValue(0)]
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class Search
    {
        [DefaultValue("")]
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
}
