using System;

static class PlayerHistory
{
    public static async Task LogInputAsync(string filePath, string input)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            await writer.WriteLineAsync($"{input}");
        }
    }
}