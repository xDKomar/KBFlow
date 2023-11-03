using Microsoft.Extensions.Configuration;
using System.Text;

var dict = new Dictionary<string, string>
{
    {"mon", "71kth5ICZrYi"},
    {"tue", "727JFEuVyRCR"},
    {"wed", "73TaKWMZTyh4"},
    {"thu", "7IzEgr0icxMl"},
    {"fri", "7JBI2BDvptRN"},
    {"sat", "7KDvnZOB7Fj7"},
    {"sun", "7LCvWC9sQrEX"},
    {"week", "SFDGpwtSDoRC"},
};
var dayName = DateTime.Now.DayOfWeek.ToString().Substring(0,3).ToLower();

if (args.Length == 0)
{
    Console.WriteLine("Params are expected");
    return;
}

var requestData = new
{
    name = string.Join(' ', args),
    columnId = dict[dayName],
    color = "white",
    swimlaneId = "pKwPyEm1lChZ",
    position = "top"
};

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var secretProvider = config.Providers.First();
secretProvider.TryGet("api-token", out var token);

var json = System.Text.Json.JsonSerializer.Serialize(requestData);
var content = new StringContent(json, Encoding.UTF8, "application/json");
var client = new HttpClient();
var url = $"https://kanbanflow.com/api/v1/tasks?apiToken={token}";
using var response = await client.PostAsync(url, content);

response.EnsureSuccessStatusCode();