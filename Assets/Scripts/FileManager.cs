using UnityEngine;
using System.IO; //Jotta voidaan käyttää System.Path:ia ja Directory:a
using System;
using Newtonsoft.Json;

public static class FileManager 
{
    public static void Save(GameData data ,string fileName)
    {
                                        // Assets/Saves/save.json      
        string fullPath = Path.Combine(Application.dataPath,"Saves",fileName);
        
        try
        {
            // Luodaan (Saves)-hakemisto, jos sitä ei löydy
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            // GetDirectoryName poistaa tiedoston nimen pathista

            // Serialisoidaan (konvertoidaan) C# GameData-luokan olio (data) JSON-muotoon
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log(jsonData);
            //KUTSU Save-funktiota jotenkin Unitystä, tee esim. Save-nappi UI:hin
            //JA/ TAI Jos painaa F5, Save-funktiota kutsutaan 
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
}
