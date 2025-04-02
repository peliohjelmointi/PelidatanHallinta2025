using UnityEngine;


[CreateAssetMenu(fileName ="PlayerStartPosition", menuName ="Player/PlayerPosition")]
public class PlayerPositionSO : ScriptableObject
{
    public Vector3 playerStartPosition;
    public Vector3 playerRotation;
}
