<Query Kind="Program">
  <NuGetReference>CloudStructures</NuGetReference>
  <Namespace>CloudStructures</Namespace>
</Query>

// Settings should holds in static variable
public static class RedisServer
{
    public static readonly RedisSettings Default = new RedisSettings("127.0.0.1");
}

class Holiday
{
	public DateTime Date { get; set; }
	public string Name { get; set; }
}

async void Main()
{
	var list = new RedisList<Holiday>(RedisServer.Default, "holidays");
	await list.Delete();
	await list.LeftPush( new [] {
		new Holiday { Date = DateTime.Parse("2016/1/1"), Name = "元日" },
		new Holiday { Date = DateTime.Parse("2016/1/11"), Name = "成人の日" },
		new Holiday { Date = DateTime.Parse("2016/2/11"), Name = "建国記念の日" },
		new Holiday { Date = DateTime.Parse("2016/3/20"), Name = "春分の日" },
		new Holiday { Date = DateTime.Parse("2016/4/29"), Name = "昭和の日" },
		new Holiday { Date = DateTime.Parse("2016/5/3"), Name = "憲法記念日" },
		new Holiday { Date = DateTime.Parse("2016/5/4"), Name = "みどりの日" },
		new Holiday { Date = DateTime.Parse("2016/5/5"), Name = "こどもの日" },
		new Holiday { Date = DateTime.Parse("2016/7/18"), Name = "海の日" },
		new Holiday { Date = DateTime.Parse("2016/8/11"), Name = "山の日" },
		new Holiday { Date = DateTime.Parse("2016/9/19"), Name = "敬老の日" },
		new Holiday { Date = DateTime.Parse("2016/9/22"), Name = "秋分の日" },
		new Holiday { Date = DateTime.Parse("2016/10/10"), Name = "体育の日" },
		new Holiday { Date = DateTime.Parse("2016/11/3"), Name = "文化の日" },
		new Holiday { Date = DateTime.Parse("2016/11/23"), Name = "勤労感謝の日" },
		new Holiday { Date = DateTime.Parse("2016/12/23"), Name = "天皇誕生日" },
		new Holiday { Date = DateTime.Parse("2017/1/1"), Name = "元日" },
		new Holiday { Date = DateTime.Parse("2017/1/9"), Name = "成人の日" },
		new Holiday { Date = DateTime.Parse("2017/2/11"), Name = "建国記念の日" },
		new Holiday { Date = DateTime.Parse("2017/3/20"), Name = "春分の日" },
		new Holiday { Date = DateTime.Parse("2017/4/29"), Name = "昭和の日" },
		new Holiday { Date = DateTime.Parse("2017/5/3"), Name = "憲法記念日" },
		new Holiday { Date = DateTime.Parse("2017/5/4"), Name = "みどりの日" },
		new Holiday { Date = DateTime.Parse("2017/5/5"), Name = "こどもの日" },
		new Holiday { Date = DateTime.Parse("2017/7/17"), Name = "海の日" },
		new Holiday { Date = DateTime.Parse("2017/8/11"), Name = "山の日" },
		new Holiday { Date = DateTime.Parse("2017/9/18"), Name = "敬老の日" },
		new Holiday { Date = DateTime.Parse("2017/9/23"), Name = "秋分の日" },
		new Holiday { Date = DateTime.Parse("2017/10/9"), Name = "体育の日" },
		new Holiday { Date = DateTime.Parse("2017/11/3"), Name = "文化の日" },
		new Holiday { Date = DateTime.Parse("2017/11/23"), Name = "勤労感謝の日" },
		new Holiday { Date = DateTime.Parse("2017/12/23"), Name = "天皇誕生日" },
		new Holiday { Date = DateTime.Parse("2018/1/1"), Name = "元日" },
		new Holiday { Date = DateTime.Parse("2018/1/8"), Name = "成人の日" },
		new Holiday { Date = DateTime.Parse("2018/2/11"), Name = "建国記念の日" },
		new Holiday { Date = DateTime.Parse("2018/3/21"), Name = "春分の日" },
		new Holiday { Date = DateTime.Parse("2018/4/29"), Name = "昭和の日" },
		new Holiday { Date = DateTime.Parse("2018/5/3"), Name = "憲法記念日" },
		new Holiday { Date = DateTime.Parse("2018/5/4"), Name = "みどりの日" },
		new Holiday { Date = DateTime.Parse("2018/5/5"), Name = "こどもの日" },
		new Holiday { Date = DateTime.Parse("2018/7/16"), Name = "海の日" },
		new Holiday { Date = DateTime.Parse("2018/8/11"), Name = "山の日" },
		new Holiday { Date = DateTime.Parse("2018/9/17"), Name = "敬老の日" },
		new Holiday { Date = DateTime.Parse("2018/9/23"), Name = "秋分の日" },
		new Holiday { Date = DateTime.Parse("2018/10/8"), Name = "体育の日" },
		new Holiday { Date = DateTime.Parse("2018/11/3"), Name = "文化の日" },
		new Holiday { Date = DateTime.Parse("2018/11/23"), Name = "勤労感謝の日" },
		new Holiday { Date = DateTime.Parse("2018/12/23"), Name = "天皇誕生日" },
	});
	var holidays = await list.Range();
	holidays.Dump();
}