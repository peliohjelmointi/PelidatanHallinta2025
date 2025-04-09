using UnityEngine;

public class Sphere : MonoBehaviour, ISaveable
{
    public string id;
    bool isCollected = false; //oletuksena false, jos ei asetettu

    [ContextMenu("Generate GUID")]
    void GenerateGUID()
    {
        id = System.Guid.NewGuid().ToString(); //Generoi random-integerin (128-bit)
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        isCollected = true;
    }


    public void LoadGameData(GameData data)
    {
        data.spheresCollected.TryGetValue(id, out isCollected); //ei herjaa, jos id:tä ei löydy

        if(isCollected) //arvo oli data:ssa true = sphere oli jo kerätty
        {
            gameObject.SetActive(false);
        }
        else // ei oltu vielä kerätty, näytetään pelaajalle (aktiivinen gameobject)
        {
            gameObject.SetActive(true);
        }
        
    }


    //rb = GetComponent<Rigidbody>(); //null reference exception jos ei ole rigidbodya

    public void SaveGameData(GameData data)
    {

       

        if (data.spheresCollected.ContainsKey(id)) //onko tämä pallo jo tallennettu?
        {
            //jos on, niin poistetaan se sieltä                                            
            data.spheresCollected.Remove(id);
        }
        data.spheresCollected.Add(id, isCollected);
    }
}
