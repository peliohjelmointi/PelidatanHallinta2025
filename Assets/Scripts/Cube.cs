using UnityEngine;

public class Cube : MonoBehaviour, ISaveable
{
    public void LoadGameData(GameData data)
    {
        transform.position = data.cubePosition;
    }

    public void SaveGameData(GameData data)
    {
       
    }
}
