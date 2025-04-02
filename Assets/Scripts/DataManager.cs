using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    GameData data;

    List<ISaveable> saveableObjects;

    public PlayerPositionSO playerStartPositionSO;

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

}
