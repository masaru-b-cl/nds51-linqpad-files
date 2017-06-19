<Query Kind="Statements" />

var source = new [] {0, 5, 10, 70, 80, 80, 82, 85, 93, 95};

// 件数
var count = source.Count().Dump("count");
source
	.Aggregate(
		0,
		(accumulate, value) => accumulate + 1
	).Dump("count by aggregate");

// 総和
var sum = source.Sum().Dump("sum");
source
	.Aggregate(
		0,
		(accumulate, value) => accumulate + value
	).Dump("sum by aggregate");

// 平均
var average = source.Average().Dump("average");
source
	.Aggregate(
		(Sum: 0, Count: 0),
		(accumulate, value) =>
			(
				Sum: accumulate.Sum + value,
				Count: accumulate.Count + 1
			),
		accumulate => (double)accumulate.Sum / accumulate.Count
	).Dump("average by aggregate");

// 分散
var variance = source
	.Select(value => value - average)
	.Select(subtraction => subtraction * subtraction)
	.Average()
	.Dump("variance");
source
	.Aggregate(
		(Sum: 0, SquaredSum: 0, Count: 0),
		(accumulate, value) =>
			(
				Sum: accumulate.Sum + value,
				SquaredSum: accumulate.SquaredSum + value * value,
				Count: accumulate.Count + 1
			),
		accumulate => {
			var averageOfSquaredValue = (double)accumulate.SquaredSum / accumulate.Count;
			var averageOfRawValue = (double)accumulate.Sum / accumulate.Count;
			return averageOfSquaredValue - averageOfRawValue * averageOfRawValue;
		}
	).Dump("variance by aggregate");

// 標準偏差
var standardDeviation = Math.Sqrt(variance).Dump("standard deviation");
source
	.Aggregate(
		(Sum: 0, SquaredSum: 0, Count: 0),
		(accumulate, value) =>
			(
				Sum: accumulate.Sum + value,
				SquaredSum: accumulate.SquaredSum + value * value,
				Count: accumulate.Count + 1
			),
		accumulate => {
			var averageOfSquaredValue = (double)accumulate.SquaredSum / accumulate.Count;
			var averageOfRawValue = (double)accumulate.Sum / accumulate.Count;
			return Math.Sqrt(averageOfSquaredValue - averageOfRawValue * averageOfRawValue);
		}
	).Dump("standard deviation by aggregate");