第51回 長岡IT開発者勉強会 発表資料のデモ
=====

本リポジトリは[第51回勉強会(2017/03/25) - 長岡 IT開発者 勉強会(NDS)](http://nagaoka.techtalk.jp/no51)のセッション、[Let's LINQing!](https://www.slideshare.net/masaru_b_cl/lets-linqing-by-masarubcl-nds51)で使用したサンプル及びデモコードです。

## 必要要件

- Windows 7 or higher
- .NET Framework 4.6 or higher
- [LINQPad](http://www.linqpad.net/) 5 or higher

## 実行方法

1. リポジトリをクローンするかzipでダウンロードして展開する
2. フォルダーを開き、`*.linq`ファイルをダブルクリックしてLINQPadで開く
3. LINQPadで`F5`キーを押して実行する

## 構成

### LINQ to CSV

国民の祝日について - 内閣府 : http://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html

で公開されているCSVファイルに対するLINQ

#### その1

公開当初の一時話題となったあの形式

- [traditional_syukujitsu.csv](syukujitsu.csv)
- [TraditionalSyukujitsu.linq](syukujitsu.linq)

#### その2

現在の形式

- [syukujitsu.csv](syukujitsu.csv)
- [Syukujitsu.linq](syukujitsu.linq)

### LINQ to XML

XMLファイルに対するLINQ

- [Holidays.xml](Holidays.xml)
- [Xml.linq](Xml.linq)

### LINQ to Excel

Excelブックに対するLINQ

- [syukujitsu.xlsx](syukujitsu.xlsx)
- [Excel.linq](Excel.linq)

### LINQ to SQLite

SQLiteに対するLINQ

- [nds51.db](nds51.db) : SQLiteデータベースファイル
- [SQLite.linq](SQLite.linq)

### LINQ to Redis

Redisに対するLINQ

- [SetupRedis.linq](SetupRedis.linq) : Redisにテストデータを登録する
- [Redis.linq](Redis.linq)

### セッションデモ

LINQによるデータ処理の実例

- [Practice.linq](Practice.linq)

### おまけ

LINQによる件数、総和、平均、最大、分散、標準偏差の計算

- [Stats.linq](Stats.linq)

## ライセンス

- zlib/libpng  
  https://opensource.org/licenses/Zlib

