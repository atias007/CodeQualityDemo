// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Xml.Linq;

// ---------------------------- Chunk ----------------------------

var usersName = new string[] { "Amit", "Neetin", "Anup", "Dinesh", "Mayur", "Kartik" };

// The old way
var userNames1st = usersName.Take(3);
var userNames2nd = usersName.Skip(3).Take(3);

// the new way
var clusterNames = usersName.Chunk(3);

// print the result
foreach (var name in clusterNames)
{
    Console.WriteLine($"Cluster of {string.Join(", ", name)}");
}

var list = Enumerable.Range(1, 125);
var chunkSize = 10;
var result = list.Chunk(chunkSize);

// ---------------------------- Zip ----------------------------
int[] numbers = { 1, 2, 3, 4 };
string[] words = { "one", "two", "three" };
var numbersAndWords = numbers.Zip(words, (first, second) => string.Concat(first, ":- ", second));

int[] ages = { 33, 30, 29 };
var combineAges = usersName.Zip(ages);

// ---------------------------- MinBy, MaxBy ----------------------------
var youngestMember = combineAges.OrderBy(x => x.Second).First();
var seniorMember = combineAges.OrderByDescending(x => x.Second).First();

var i_youngestMember = combineAges.Min(x => x.Second);
var i_seniorMember = combineAges.Max(x => x.Second);

youngestMember = combineAges.MinBy(x => x.Second);
seniorMember = combineAges.MaxBy(x => x.Second);

// ---------------------------- ElementAt ----------------------------
string[] fourUsers = usersName[1..4];
string[] firstTwoUsers = usersName[0..2];
string[] allUsers = usersName[..]; // contains all through it.
string[] firstFourUsers = usersName[..4]; // contains The first four users
string[] lastPhrase = usersName[6..]; // contains the last three from 6th

var demo = "abcdefghijkl";
var scope2 = demo[2..^2];
var scope = demo[0..(1 + 1)];

// ---------------------------- First Or Default ----------------------------
var numbers2 = new List<int>() { 7, 1, 9, 41, 8, 22 };
var matchingNumber1 = numbers2.FirstOrDefault(x => x > 50, -1); //-1
var matchingNumber2 = numbers2.SingleOrDefault(x => x > 30, -1); //41

var emptyCollection = new List<string>();
var firstName = emptyCollection.FirstOrDefault("Nothing Found"); //Nothing Found

// ---------------------------- DateTime vs. DateTimeOffset  ----------------------------

var now2 = DateTime.Now;
var now3 = DateTimeOffset.UtcNow;

var now1 = DateTimeOffset.UtcNow;

Console.ReadLine();