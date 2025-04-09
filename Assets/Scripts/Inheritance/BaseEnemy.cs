using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public abstract class BaseEnemy : MonoBehaviour
{
    protected GameObject player;
    protected NavMeshAgent agent;

    //[SerializeField]
    //protected float agroRange = 5;

    protected virtual void Awake()
    {
        Debug.Log("BASE ENEMY AWAKE");
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 5f)
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


