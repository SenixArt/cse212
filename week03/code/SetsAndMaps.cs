using System.Text.Json;

namespace week03;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find Pairs with Sets
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1]) continue;

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Degree Summary
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length > 3)
            {
                string degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length) return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in clean1)
        {
            if (counts.ContainsKey(c)) counts[c]++;
            else counts[c] = 1;
        }

        foreach (char c in clean2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Earthquake JSON Data
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        
        string json = client.GetStringAsync(url).Result;
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        var summary = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summary.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summary.ToArray();
    }
}

// Clases auxiliares para la deserialización JSON (Problema 5)
public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public Properties Properties { get; set; } = new();
}

public class Properties
{
    public string Place { get; set; } = "";
    public double Mag { get; set; }
}
