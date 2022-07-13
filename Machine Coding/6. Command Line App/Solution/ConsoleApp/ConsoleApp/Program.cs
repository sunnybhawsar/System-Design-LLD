using ConsoleApp.Code;

IList<string> result = new CountingNumbers().GetResult(args);

foreach (string res in result)
    Console.WriteLine(res);