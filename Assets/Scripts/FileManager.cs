using UnityEngine;
using System.IO; //Jotta voidaan käyttää System.Path:ia ja Directory:a
using System;
using Newtonsoft.Json;
using UnityEngine.Rendering.LookDev;

public static class FileManager
{
    public static GameData LoadFromFile(string directory, string fileName)
    {
        string dir = directory;
        string file = fileName;
        string fullPath = Path.Combine(dir, file);

        GameData loadedData = null; //aluksi null, jos tiedosto oikeassa
                                    //  (GameData-luokan formaatissa),
                                    // aseteaan loadedDataan tiedoston sisältö
                                    // konvertoituna JSON->Unity class (GameData class)

        //Tarkistetaan ensin, onko tiedostoa olemassa:
        if (File.Exists(fullPath))
        {
            try
            {
                string json = File.ReadAllText(fullPath);
                loadedData = JsonConvert.DeserializeObject<GameData>(json);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        return loadedData;

            
    }

    public static void SaveToFile(GameData data, string fileName)
    {
        // Assets/Saves/save.json      
        string fullPath = Path.Combine(Application.dataPath, "Saves", fileName);
        
        Debug.Log(fullPath);
        
        
        try
        {
            // Luodaan (Saves)-hakemisto, jos sitä ei löydy
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            // GetDirectoryName poistaa tiedoston nimen pathista

            // Serialisoidaan (konvertoidaan) C# GameData-luokan olio (data) JSON-muotoon                      
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            //string jsonData = JsonUtility.ToJson(data,true);
            // Unityn oma, hyvä, muttei tue esim. Dictionaryn serialisointia
            // toisin kuin Newtonsoft.Json


            //Debug.Log(jsonData);

            // Tallennetaan fullPath-muuttujassa määritettyyn tiedostoon
            File.WriteAllText(fullPath, jsonData);
            // Luo tiedoston, jos ei löydy, yliajaa jos löytyy
            // UTF-8 oletuksena, ei tarvitse määrittää (mutta voi)            

            // HUOM. Löytyy myös AppendAllText


        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
}
