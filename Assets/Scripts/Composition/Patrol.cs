using UnityEngine;

public class Patrol : CompositionBaseEnemy, IEnemy
{
    public void Perform(CompositionBaseEnemy enemy)
    {
        enemy.transform.Rotate(new Vector3(0f, 180f, 0f) * Time.deltaTime);
    }
}
