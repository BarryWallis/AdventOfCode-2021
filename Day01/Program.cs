// See https://aka.ms/new-console-template for more information
int[] window = new int[3];
string? line = Console.ReadLine() ?? throw new InvalidOperationException("Not enough measurements.");
window[0] = ParseInt(line);

line = Console.ReadLine() ?? throw new InvalidOperationException("Not enough measurements.");
window[1] = ParseInt(line);

line = Console.ReadLine() ?? throw new InvalidOperationException("Not enough measurements.");
window[2] = ParseInt(line);

int oldMeasurement = window[0] + window[1] + window[2];
int count = 0;
while ((line = Console.ReadLine()) != null)
{
    window[0] = window[1];
    window[1] = window[2];
    window[2] = ParseInt(line);
    int newMeasurement = window[0] + window[1] + window[2];
    count += newMeasurement > oldMeasurement ? 1 : 0;
    oldMeasurement = newMeasurement;
}

Console.WriteLine($"Result is {count}");

static int ParseInt(string line) => int.TryParse(line, out int m) ? m : throw new InvalidCastException("Expected integer.");
