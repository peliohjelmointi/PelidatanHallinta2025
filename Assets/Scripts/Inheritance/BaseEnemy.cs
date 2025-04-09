using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{
    protected GameObject gameObjectToFollow;
    protected NavMeshAgent agent;


    protected virtual void Awake()
    {
        Debug.Log("BASE ENEMY AWAKE");
        gameObjectToFollow = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(gameObjectToFollow.transform.position, gameObject.transform.position) < 5f)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    protected virtual void Attack()
    {
        Debug.Log("DEFAULT ATTACK, NON-VIOLENT TEXT ATTACK (angry!");        
    }

    protected virtual void Patrol()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f) * Time.deltaTime);
    }


}


