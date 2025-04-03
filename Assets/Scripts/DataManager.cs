using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    GameData data; //toistaiseksi null

    List<ISaveable> saveableObjects;

    public PlayerPositionSO playerStartPositionSO;

    [Header("Save/Load file name")]
    [SerializeField]
    string fileName;

    private void Start()
    {       
        //Startissa,eikä Awakessa jotta FindObjectsByType toimii varmasti
        saveableObjects = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, 
                                                            FindObjectsSortMode.None) 
                                                        .OfType<ISaveable>().ToList();
        LoadGame();
    }

    public void LoadGame()
    {
        data = new GameData(playerStartPositionSO); //luodaan olio, ajaa konstruktorin

        //Kutsutaan LoadGameData jokaisessa skriptissä jossa ISaveable
        foreach (var script in saveableObjects)
        {
            script.LoadGameData(data);
        }
    }

    public void SaveGame()
    {
        foreach (var script in saveableObjects)
        {
            script.SaveGameData(data); //nappaa skripteistä esim.
                                    //positiot data-olioon
        }
        // Tallennetaan data-olio tiedostoon FileManagerilla
        FileManager.Save(data,fileName);
    }
}
