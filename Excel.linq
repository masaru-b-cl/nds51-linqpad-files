<Query Kind="Statements">
  <NuGetReference>ClosedXML</NuGetReference>
  <Namespace>ClosedXML.Excel</Namespace>
</Query>

var dataSource = new ClosedXML.Excel.XLWorkbook("syukujitsu.xlsx")
	.Worksheet(1)
	.Rows()
	.Skip(1)
	.Select(row => (Date: (DateTime)row.Cell(1).Value, Name: row.Cell(2).Value as string));

dataSource
	.Where(h => h.Date >= new DateTime(2017,  1,  1))
	.Where(h => h.Date <= new DateTime(2017, 12, 31))
	.OrderByDescending(h => h.Date)
	.Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
	.Dump();