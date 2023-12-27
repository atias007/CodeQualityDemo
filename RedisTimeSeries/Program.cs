using NRedisTimeSeries.Commands.Enums;
using NRedisTimeSeries.DataTypes;
using NRedisTimeSeries;
using StackExchange.Redis;

var redis = ConnectionMultiplexer.Connect("localhost");
var db = redis.GetDatabase();

// Create
var label = new TimeSeriesLabel("region", "tel-aviv");
////var retentionTime = Convert.ToInt32(TimeSpan.FromHours(1).TotalMilliseconds);
////db.TimeSeriesCreate("sensor1", retentionTime: retentionTime, labels: new List<TimeSeriesLabel> { label }, duplicatePolicy: TsDuplicatePolicy.MAX);

////// Create Rule
////db.TimeSeriesCreate("sensor1_compacted", retentionTime: retentionTime);
////var rule = new TimeSeriesRule("sensor1_compacted", 1000, TsAggregation.Avg);
////db.TimeSeriesCreateRule("sensor1", rule);

// Add data
while (true)
{
    var value = new Random().NextDouble() * 10000;
    db.TimeSeriesAdd("sensor1", "*", value);
    Console.WriteLine(value);
    Thread.Sleep(20);
}