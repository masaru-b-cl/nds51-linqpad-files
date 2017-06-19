<Query Kind="Statements" />

// 新入社員研究カリキュラムの実績工数を分析する
var rawData = @"カテゴリー	名前	社員1	社員2	社員3	社員4	社員5
テキスト	A	2	5	2	3	5
テキスト	B	2	3	2	2	2
テキスト	C	2	2	2	4	2
実習	A | フェーズ1	3	3	2	3	2
実習	A | フェーズ2	3	3	1	4	2
テキスト	D	3	3	2	2	4
テキスト	E	8	8	9	8	9
テキスト	F	4	3	3	2	2
テキスト	G	3	3	2	2	2
実習	B	3	9	4	5	5
実習	C | フェーズ1	2	4	2	3	4
実習	C | フェーズ2	9	7	4	8	10
実習	C | フェーズ3	3	2	4	6	3
テキスト	H	3	1	3	2	2
テキスト	I	5	4	5	5	5
テキスト	J	3	2	1		2
実習	D | フェーズ1	10	15	10		12
実習	D | フェーズ2	8	8	5		11
実習	D | フェーズ3	12	8	8		14
実習	D | フェーズ4	6	7	7		10";

// 集計用にデータを整形
var dataSource = rawData
	.Split(new string[]{Environment.NewLine}, StringSplitOptions.None)
	.Skip(1)
	.Select(line => line.Split('\t'))
	.Select(items => (
		Category: items[0],
		Name: items[1],
		Costs: items
			.Skip(2)
			.Where(x => !String.IsNullOrEmpty(x))
			.Select(x => Int32.Parse(x))
			.ToArray()
		))
	.Dump();

// 集計
var stats = dataSource
	.Select(entry => new {
		Category = entry.Category,
		Name = entry.Name,
		Min = entry.Costs.Min(),
		Max = entry.Costs.Max(),
		Average = entry.Costs.Average(),
		// 標準偏差：分散の平方根
		StandardDeviation = Math.Round(
			Math.Sqrt(
				// 分散：二乗平均 - 平均の二乗
				entry.Costs.Select(cost => cost * cost).Average() -
					entry.Costs.Average() * entry.Costs.Average()
			),
			2
		)
	})
	.Dump();

// 標準偏差が小さい順に並べる
stats
	.OrderBy(entry => entry.StandardDeviation)
	.Dump();

// 実習カテゴリーごとに標準偏差の平均を出す
stats
	.GroupBy(entry => entry.Category)
	.Select(group => new {
		Category = group.Key,
		AverageOfStandardDeviation = group.Average(entry => entry.StandardDeviation)
		})
	.Dump();