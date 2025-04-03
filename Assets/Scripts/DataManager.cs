using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    GameData data; //toistaiseksi null

    List<ISaveable> saveableObjects;

    //public PlayerPositionSO playerStartPositionSO;

    [Header("Save/Load file name")]
    [SerializeField]
    string fileName;

    private void Start()
    {       
        //Startissa,eik‰ Awakessa jotta FindObjectsByType toimii varmasti
        saveableObjects = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, 
                                                            FindObjectsSortMode.None) 
                                                        .OfType<ISaveable>().ToList();
        LoadGame();
    }

    public void LoadGame()
    {
        // tarkistetaan, onko Datamanagerissa oleva save file  olemassa, ja jos on, ladataan se.
        // Jos ei, luodaan uusi olio GameDatasta, jolloin haetaan oletusarvot SO:sta

        // koitetaan ladata file:
        Debug.Log("fileName=" + fileName);
        data = FileManager.LoadFromFile(Application.dataPath + "/Saves", fileName);

        if(data == null) //ei saatu jostain syyst‰ ladattua tiedostosta
        {
            Debug.Log("Tiedostoa ei ollut tai v‰‰r‰ formaatti. Luodaan alkupositiot");
            
            //EI TOIMINUT KAIKILLA, MIKSEI?
            //data = new GameData(playerStartPositionSO); //luodaan olio, ajaa konstruktorin
            
            data = new GameData(); //luodaan olio, ajaa konstruktorin
        }
      
        //Kutsutaan LoadGameData jokaisessa skriptiss‰ jossa ISaveable
        foreach (var script in saveableObjects)
        {
            script.LoadGameData(data);
        }
    }

    public void SaveGame()
    {
        foreach (var script in saveableObjects)
        {
            script.SaveGameData(data); //nappaa skripteist‰ esim.
                                    //positiot data-olioon
        }
        // Tallennetaan data-olio tiedostoon FileManagerilla
        FileManager.SaveToFile(data,fileName);
    }
}
