using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

public class StarCatalog
{
    public List<Star> Stars { get; set; } = new List<Star>();

    public void SaveToFile(string path)
    {
        var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static StarCatalog LoadFromFile(string path)
    {
        if (!File.Exists(path)) return new StarCatalog();
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<StarCatalog>(json) ?? new StarCatalog();
    }

    public List<Star> GetBrightestStars(int count)
    {
        return Stars.OrderBy(s => s.Magnitude).Take(count).ToList();
    }

    public List<Star> FilterByConstellation(string constellationName)
    {
        return Stars.Where(s => s.Constellation == constellationName).ToList();
    }
}