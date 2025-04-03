using UnityEngine;

public class GameData 
{
    public Vector3 playerPosition;
    public Vector3 playerRotation;

    public Vector3 cubePosition;

    public GameData(PlayerPositionSO playerPositionSO)
    {
        Debug.Log("GameData constructor");

        playerPosition = playerPositionSO.playerStartPosition;        
        playerRotation = playerPositionSO.playerRotation;

        cubePosition = Vector3.zero;
    }
    
}

