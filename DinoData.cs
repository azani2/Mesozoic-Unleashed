using UnityEngine;

[System.Serializable]
public class DinoData
{
    public int id;
    public string animal;
    public string common_name;
    public string name_meaning;
    public string period;
    public string epoch;
    public string genus;
    public string diet_key;
    public string diet_elaboration;
    public string height;
    public string weight;
    public string environment;
    public string climate;
    public string area;
    public string physical_characteristics;
    public string thermoregulation;
    public string extinction;
    public string extinction_event;
    public string modern_close_relatives;

    public bool animal_discovered; // 1
    public bool common_name_discovered; // 2
    public bool name_meaning_discovered; // 3
    public bool period_discovered; // 4
    public bool epoch_discovered; // 5
    public bool genus_discovered; // 6
    public bool diet_key_discovered; // 7
    public bool diet_elaboration_discovered; // 8
    public bool height_discovered; // 9
    public bool weight_discovered; // 10
    public bool environment_discovered; // 11
    public bool climate_discovered; // 12
    public bool area_discovered; // 13
    public bool physical_characteristics_discovered; // 14
    public bool thermoregulation_discovered; // 15
    public bool extinction_discovered; // 16
    public bool extinction_event_discovered; // 17
    public bool modern_close_relatives_discovered; // 18

    public string getCharacteristicByIdx(int idx)
    {
        switch (idx)
        {
            case 1: { return animal; }
            case 2: { return common_name; }
            case 3: { return name_meaning; }
            case 4: { return period; }
            case 5: { return epoch; }
            case 6: { return genus; }
            case 7: { return diet_key; }
            case 8: { return diet_elaboration; }
            case 9: { return height; }
            case 10: { return weight; }
            case 11: { return environment; }
            case 12: { return climate; }
            case 13: { return area; }
            case 14: { return physical_characteristics; }
            case 15: { return thermoregulation; }
            case 16: { return extinction; }
            case 17: { return extinction_event; }
            case 18: { return modern_close_relatives; }
            default: { return null; }
        }
    }
}