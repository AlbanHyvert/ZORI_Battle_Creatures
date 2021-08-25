using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Libcsv: MonoBehaviour
{
    private string m_filename;
    private List<string> m_keys;
    private List<Dictionary<String, String>> m_elements;
    private TextWriter errorWriter;

    public string filename { get => m_filename; }

    /// <summary>
    ///  Constructor of libCSV
    /// </summary>
    public void Init()
    {
        m_elements = new List<Dictionary<String, String>>();
        m_keys = new List<string>();
        m_filename = null;
        errorWriter = Console.Error;
    }

    /// <summary>
    ///  Read the CSV
    /// </summary>
    public bool read_csv(string filename, char delimiter = ';')
    {
        m_filename = filename;
        if (!File.Exists(m_filename))
        {
            errorWriter.WriteLine("File not found!");
            return false;
        }
        string[] lines = System.IO.File.ReadAllLines(m_filename);
        m_keys = lines[0].Split(delimiter).ToList();
        for (int i = 1; i < lines.Length; ++i)
        {
            Dictionary<String, String> dict = new Dictionary<string, string>();
            var lines_splited = lines[i].Split(delimiter).ToList();
            if (lines_splited.Count > m_keys.Count)
            {
                errorWriter.WriteLine("Index {0}, Invalid CSV, element size is greater than key size", (i - 1));
                return false;
            }
            for (int j = 0; j < m_keys.Count; ++j)
            {
                dict.Add(m_keys[j], lines_splited[j]);
            }

            m_elements.Add(dict);
        }

        Console.WriteLine(m_elements.Count);
        return true;
    }

    public List<Item> ToItem()
    {
        List<Item> list_item = new List<Item>();
        foreach (var dict in m_elements)
        {
            Item item = toItem(dict);
            list_item.Add(item);
        }
        return list_item;
    }

    private Item toItem(Dictionary<string, string> values)
    {
        E_Pocket pocket = ToPocket(values[m_keys[1]]);
        if (pocket == E_Pocket.UNKNOWN)
        {
            errorWriter.WriteLine("Pocket type object is unknown ! ({0})", values[m_keys[1]]);
            return null;
        }
        E_ObjectType type = ToType(values[m_keys[2]]);
        if (type == E_ObjectType.UNKNOWN)
        {
            errorWriter.WriteLine("Type object is unknown ! ({0})", values[m_keys[2]]);
            return null;
        }
        uint purchasing_price = values[m_keys[5]] != "N/A" && values[m_keys[5]].Length > 0 ? Convert.ToUInt32(values[m_keys[5]].Substring(0, values[m_keys[5]].Length - 2)) : 0;
        uint sale_price = values[m_keys[6]] != "N/A" && values[m_keys[6]].Length > 0 ? Convert.ToUInt32(values[m_keys[6]].Substring(0, values[m_keys[6]].Length - 2)) : 0;
        Item item = new Item();
        item.Init(values[m_keys[0]], pocket, type, values[m_keys[3]], values[m_keys[4]], purchasing_price, sale_price);
        return item;
    }

    public static E_Pocket ToPocket(string value)
    {
        switch (value)
        {
            case "Medicine":
                return E_Pocket.MEDICINE;
            case "Cryst\'Aura":
                return E_Pocket.CRYSTAURA;
            case "Battle Items":
                return E_Pocket.BATTLEITEM;
            case "Power-Ups":
                return E_Pocket.POWERUPS;
            case "Treasures":
                return E_Pocket.TREASURE;
            case "Key Items":
                return E_Pocket.KEYITEM;
            case "Zori Food":
                return E_Pocket.ZORIFOOD;
            case "Essentials":
                return E_Pocket.ESSENTIAL;
            default:
                return E_Pocket.UNKNOWN;
        }
        return E_Pocket.UNKNOWN;
    }

    public static E_ObjectType ToType(string value)
    {
        switch (value)
        {
            case "Escape / Repels Item":
                return E_ObjectType.ESCAPE;
            case "Evolution Item":
                return E_ObjectType.EVOLUTION;
            case "Valuable / Exchangeable item":
                return E_ObjectType.VALUABLE_EXCHANGE;
            case "Held Item":
                return E_ObjectType.HELD;
            case "Cryst\'Aura":
                return E_ObjectType.CRYSTAURA;
            case "HP-restoring item":
                return E_ObjectType.HP_RESTORING;
            case "Afflictions curing item":
                return E_ObjectType.AFFLICATION;
            case "Reviving item":
                return E_ObjectType.REVIVING;
            case "Stamina restoring item":
                return E_ObjectType.STAMINA;
            case "Stats increasing item":
                return E_ObjectType.STAT_INCREASING;
            case "Ability changing item":
                return E_ObjectType.ABILITY;
            case "Technique learning item":
                return E_ObjectType.TECHNIQUE_LEARNING;
            case "Story related item":
                return E_ObjectType.STORY_RELATED;
            case "Synergy related item":
                return E_ObjectType.SYNERGY;
            case "Capture helper":
                return E_ObjectType.CAPTURE;
            default:
                return E_ObjectType.UNKNOWN;
        }
        return E_ObjectType.UNKNOWN;
    }
    public void print()
    {
        foreach (var element in m_elements)
        {
            foreach (KeyValuePair<string, string> kvp in element)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
