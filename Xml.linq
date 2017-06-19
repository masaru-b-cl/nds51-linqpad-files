<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Linq.dll</Reference>
  <Namespace>System.Xml.Linq</Namespace>
</Query>

var dataSource = XDocument.Load("Holidays.xml")
	.Descendants("Holiday")
	.Select(element =>
		(
			Date: DateTime.Parse(element.Element("Date").Value),
			Name: element.Element("Name").Value
		)
	);


dataSource
	.Where(h => h.Date >= new DateTime(2017,  1,  1))
	.Where(h => h.Date <= new DateTime(2017, 12, 31))
	.OrderByDescending(h => h.Date)
	.Select(h => $"{h.Date:yyyy/MM/dd} ( {h.Name} )")
	.Dump();