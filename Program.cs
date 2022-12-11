// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bogus;

Console.WriteLine("Generate Random String");

/*
List<string> randomStringUsingRandom = new List<string>();

var stopWatch = new Stopwatch();
stopWatch.Start();
for (int i = 0; i < 1000000; i++)
{
    var randomStringGenerator = new RandomString();
    var randomString = randomStringGenerator.GenerateUsingRandom(10);
    randomStringUsingRandom.Add(randomString);
}
stopWatch.Stop();
Console.WriteLine($"Time taken to generate 1 million random strings using Random class: {stopWatch.ElapsedMilliseconds} ms");

//print 10 strings from the list 
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(randomStringUsingRandom[i]);
}

var duplicates = randomStringUsingRandom.GroupBy(x => x)
    .Where(g => g.Count() > 1)
    .Select(y => y.Key)
    .ToList();

Console.WriteLine("Duplicates: " + duplicates.Count);
*/

BenchmarkRunner.Run<RandomString>();

//Console.ReadLine();

[MemoryDiagnoser]
public class RandomString
{
    [Benchmark]
    public string GenerateUsingRandom()
    {
        string randomString = "";
        Random random = new();
        for (int i = 0; i < 11; i++)
        {
            int randomInt = random.Next(0, 62);
            randomString += randomInt switch
            {
                < 11 => randomInt.ToString(),
                < 36 => randomInt + 55,
                _ => randomInt + 61
            };
        }
        return randomString.ToUpper();
    }
    
    /*
    [Benchmark]
    public string GenerateUsingRandom(int length)
    {
        string randomString = "";
        Random random = new();
        for (int i = 0; i < length; i++)
        {
            int randomInt = random.Next(0, 62);
            if (randomInt < length)
            {
                randomString += randomInt.ToString();
            }
            else if (randomInt < 36)
            {
                randomString += (char)(randomInt + 55);
            }
            else
            {
                randomString += (char)(randomInt + 61);
            }
        }
        return randomString.ToUpper();
    }
    */
    
    [Benchmark]
    public string RandomStringGeneratorUsingBogus()
    {
        return new Faker().Random.AlphaNumeric(10).ToUpper();
    }
}