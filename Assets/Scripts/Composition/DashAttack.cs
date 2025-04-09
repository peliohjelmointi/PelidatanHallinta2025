using UnityEngine;

public class DashAttack : CompositionBaseEnemy, IEnemy
{
    public void Perform(CompositionBaseEnemy enemy)
    {
        Debug.Log("DASH ATTACK!!");
    }
}
