using UnityEngine;
using UnityEngine.AI;

public class Attack : CompositionBaseEnemy, IEnemy
{

    public void Perform(CompositionBaseEnemy enemy)
    {
        enemy.GetComponent<NavMeshAgent>().SetDestination(Player.Instance.transform.position);
    }
}
