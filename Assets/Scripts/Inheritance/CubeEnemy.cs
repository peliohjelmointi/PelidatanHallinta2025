using UnityEngine;

public class CubeEnemy : BaseEnemy
{
    protected override void Awake()
    {
        base.Awake(); //kutsuu BaseEnemyn awakea
        Debug.Log("CUBE ENEMY AWAKE called");        
    }

    protected override void Attack()
    {
        agent.SetDestination(player.transform.position);
    }
}
