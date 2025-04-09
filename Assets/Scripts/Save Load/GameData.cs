using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Vector3 playerRotation;

    public Dictionary<string, bool> spheresCollected;

    public GameData() //jos save filea ei ole, luodaan näiden arvojen mukaan
    {
        playerPosition = new Vector3(0, 1.274f, 0);
        playerRotation = new Vector3(0, 0, 0);

        spheresCollected = new Dictionary<string, bool>();
    }

}

