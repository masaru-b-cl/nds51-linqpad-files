<Query Kind="Program">
  <NuGetReference>CloudStructures</NuGetReference>
  <Namespace>CloudStructures</Namespace>
</Query>

class Holiday
{
	public DateTime Date { get; set; }
	public string Name { get; set; }
}

async void Main()
{
	var dataSource = (await new RedisList<Holiday>(new RedisSettings("127.0.0.1"), "holidays").Range())
		.Select(holiday => (
			Date: holiday.Date.ToLocalTime(), // RedisはUnixTime（UTC）なので、JSTに変換
			Name: holiday.Name
		));

	dataSource
	  .Where(h => h.Date >= new DateTime(2017,  1,  1))
	  .Where(h => h.Date <= new DateTime(2017, 12, 31))
	  .OrderByDescending(h => h.Date)
	  .Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
	  .Dump();
}