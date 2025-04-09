using UnityEngine;
using System.IO; //Jotta voidaan k‰ytt‰‰ System.Path:ia ja Directory:a
using System;
using Newtonsoft.Json;
using UnityEditor;

public static class FileManager
{
    public static GameData LoadFromFile(string directory, string fileName)
    {
        string dir = directory;
        string file = fileName;
        string fullPath = Path.Combine(dir, file);

        GameData loadedData = null; //aluksi null, jos tiedosto oikeassa
                                    //  (GameData-luokan formaatissa),
                                    // aseteaan loadedDataan tiedoston sis‰ltˆ
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
            // Luodaan (Saves)-hakemisto, jos sit‰ ei lˆydy
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            // GetDirectoryName poistaa tiedoston nimen pathista

            // Serialisoidaan (konvertoidaan) C# GameData-luokan olio (data) JSON-muotoon                      
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            //string jsonData = JsonUtility.ToJson(data,true);
            // Unityn oma, hyv‰, muttei tue esim. Dictionaryn serialisointia
            // toisin kuin Newtonsoft.Json


            //Debug.Log(jsonData);

            // Tallennetaan fullPath-muuttujassa m‰‰ritettyyn tiedostoon
            File.WriteAllText(fullPath, jsonData);
            // Luo tiedoston, jos ei lˆydy, yliajaa jos lˆytyy
            // UTF-8 oletuksena, ei tarvitse m‰‰ritt‰‰ (mutta voi)            

            // HUOM. Lˆytyy myˆs AppendAllText

            //Otetaan screenshot, toimii t‰ss‰ vain jos Resources kansio lˆytyy
            //2D-templatessa toimii suoraan t‰ll‰ (jolloin tekee kuvasta autom. Sprite2D-tekstuurin)           
            //ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/Screenshot.png");           
            //AssetDatabase.Refresh(); //synkronisoi assets-kansion tiedot projektiin
            TakeScreenshot();
            
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
    static void TakeScreenshot()
    {
        string fileName = "Assets/Resources/Screenshot.png"; //   Assets/Resources
        string path = Application.dataPath + "/Resources";

      
        if (!Directory.Exists(path)) // jos Resources-kansiota EI lˆydy
        {
            Directory.CreateDirectory(path);
        }

        ScreenCapture.CaptureScreenshot(fileName);

        //odotetaan seuraavaan frameen, jotta tallennus on varmasti valmis
        EditorApplication.delayCall += () =>
        {
            AssetDatabase.Refresh(); //jotta Unity tiet‰‰ uudesta tiedostosta

            // Ladataan tallennettu tiedosto Spriteksi (Texture2D)
            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(fileName);

            if (texture != null) //lˆytyikˆ /onnistuiko tiedoston lataus 2d-tekstuuriksi
            {
                // asetetaan tekstuuri Spriteksi ja sprite mode:ksi single (jotka voi tehd‰ myˆs editorista)
                TextureImporter textureImporter = AssetImporter.GetAtPath(fileName) as TextureImporter;
                if (textureImporter != null)
                {
                    textureImporter.textureType = TextureImporterType.Sprite; // Default > 2D Sprite
                    textureImporter.spriteImportMode = SpriteImportMode.Single; // Multiple > Single
                    textureImporter.SaveAndReimport(); //Tallentaa muutokset tiedostoon                    
                }
            }
            else
            {
                Debug.LogWarning("Failed converting screenshot to 2d texture");
            }
        };
    }


    

}
