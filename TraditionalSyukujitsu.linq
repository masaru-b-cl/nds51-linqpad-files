<Query Kind="Statements" />

var dataSource = File.ReadLines(
		"traditional_syukujitsu.csv",
		Encoding.GetEncoding(932)
	)
	.Select(line => line.Split(','))
	.Select(items => new [] {
		(Name: items[0], RawDate: items[1]),
		(Name: items[2], RawDate: items[3]),
		(Name: items[4], RawDate: items[5])
	})
	.SelectMany(entries => entries)
	.Where(entry => DateTime.TryParse(entry.RawDate, out var _))
	.Select(entry => (Date: DateTime.Parse(entry.RawDate), Name: entry.Name));

dataSource
	.Where(h => h.Date >= new DateTime(2017,  1,  1))
	.Where(h => h.Date <= new DateTime(2017, 12, 31))
	.OrderByDescending(h => h.Date)
	.Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
	.Dump();