<Query Kind="Statements" />

var dataSource = File.ReadLines("syukujitsu.csv", Encoding.GetEncoding(932))
	.Select(line => line.Split(','))
	.Skip(1)
	.Select(items => (Date: DateTime.Parse(items[0]), Name: items[1]));

dataSource
	.Where(h => h.Date >= new DateTime(2017,  1,  1))
	.Where(h => h.Date <= new DateTime(2017, 12, 31))
	.OrderByDescending(h => h.Date)
	.Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
	.Dump();