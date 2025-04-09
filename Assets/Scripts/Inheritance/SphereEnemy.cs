using UnityEngine;

public class SphereEnemy : BaseEnemy
{
    float defaultSpeed;

    protected override void Awake()
    {
        base.Awake(); //k‰ytet‰‰n sek‰ BaseEnemyn Awakea ja t‰t‰ Awakea
        //base.gameObjectToFollow = GameObject.FindGameObjectWithTag("Cow");
        defaultSpeed = agent.speed; //speediksi 3.5
    }

    protected override void Attack()
    {
        agent.speed = defaultSpeed * 2f;
        agent.SetDestination(gameObjectToFollow.transform.position);
    }

    protected override void Patrol()
    {
        agent.speed = defaultSpeed;
        base.Patrol(); 
    }
}
