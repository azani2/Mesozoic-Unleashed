using NUnit.Framework;
using UnityEngine;
using System.IO;


[System.Serializable]
public class DinoDataWrapper
{
    public DinoData[] filetype;
}

public class DinoManager : MonoBehaviour
{
    public static DinoManager instance {  get; private set; }

    [SerializeField]
    private TextAsset dinoJsonData;
    private DinoData[] allDinos;
    public bool isLoaded = false;

    private void Awake()
    {
        instance = this;
        LoadDinoData();
        Debug.Log("allDinos length: " + allDinos.Length);
    }

    void Start()
    {
        GameEvents.current.onDiscoveredDinoInfo += UpdateDiscovery;
        DiscoverAll();
    }

    private void LoadDinoData()
    {
        allDinos = JsonUtility.FromJson<DinoDataWrapper>(dinoJsonData.text).filetype;
        instance.isLoaded = true;
        Debug.Log("Loaded successfully.");
    }

    private void UpdateDiscovery(int dinoId, int infoIdx)
    {
        if (infoIdx <= 18 && infoIdx >= 1)
        {
            switch (infoIdx)
            {
                case 1: { allDinos[dinoId].animal_discovered = true; break; };
                case 2: { allDinos[dinoId].common_name_discovered = true; break; };
                case 3: { allDinos[dinoId].name_meaning_discovered = true; break; };
                case 4: { allDinos[dinoId].period_discovered = true; break; };
                case 5: { allDinos[dinoId].epoch_discovered = true; break; };
                case 6: { allDinos[dinoId].genus_discovered = true; break; };
                case 7: { allDinos[dinoId].diet_key_discovered = true; break; };
                case 8: { allDinos[dinoId].diet_elaboration_discovered = true; break; };
                case 9: { allDinos[dinoId].height_discovered = true; break; };
                case 10: { allDinos[dinoId].weight_discovered = true; break; };
                case 11: { allDinos[dinoId].environment_discovered = true; break; };
                case 12: { allDinos[dinoId].climate_discovered = true; break; };
                case 13: { allDinos[dinoId].area_discovered = true; break; };
                case 14: { allDinos[dinoId].physical_characteristics_discovered = true; break; };
                case 15: { allDinos[dinoId].thermoregulation_discovered = true; break; };
                case 16: { allDinos[dinoId].extinction_discovered = true; break; };
                case 17: { allDinos[dinoId].extinction_event_discovered = true; break; };
                case 18: { allDinos[dinoId].modern_close_relatives_discovered = true; break; };
                default: break;
            }
        }
    }

    public DinoData GetDinoById(int dinoId)
    {
        return allDinos[dinoId];
    }

    private void DiscoverAll()
    {
        for (int i = 0; i < allDinos.Length; i++)
        {
            for (int j = 1; j <= 18; j++)
            {
                UpdateDiscovery(i, j);
            }
        }
    }
}


    