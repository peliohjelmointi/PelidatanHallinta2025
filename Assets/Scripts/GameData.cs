using UnityEngine;


[System.Serializable]
public class GameData 
{
    public Vector3 playerPosition;
    public Vector3 playerRotation;

    //public GameData(PlayerPositionSO playerPositionSO)
    //{
    //    playerPosition = playerPositionSO.playerStartPosition;
    //    playerRotation = playerPositionSO.playerRotation;
    //} 
    //CTRL+K+C = comment, CTRL+K+U = uncomment 

    public GameData()
    {
        playerPosition = new Vector3(0, 0, 0);
        playerRotation = new Vector3(0, 0, 0);
    }

}

