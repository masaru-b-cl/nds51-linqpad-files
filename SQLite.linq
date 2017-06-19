<Query Kind="Program">
  <NuGetReference>System.Data.SQLite</NuGetReference>
  <Namespace>System.Data.Linq.Mapping</Namespace>
  <Namespace>System.Data.SQLite</Namespace>
  <Namespace>System.Data.SQLite.Linq</Namespace>
</Query>

[Table(Name="Holiday")]
class Holiday
{
	[Column]
	public DateTime Date { get; set; }

	[Column]
	public string Name { get; set; }
}

void Main()
{
	var dc = new DataContext(new SQLiteConnection("Data Source=nds51.db"));
	dc.Log = Console.Out;
	var dataSource = dc
		.GetTable<Holiday>();
	
	
	dataSource
		.Where(h => h.Date >= new DateTime(2017,  1,  1))
		.Where(h => h.Date <= new DateTime(2017, 12, 31))
		.OrderByDescending(h => h.Date)
		.Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
		.Dump();
}