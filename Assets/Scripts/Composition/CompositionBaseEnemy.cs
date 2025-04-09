using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(DashAttack))]
[RequireComponent(typeof(Patrol))]

public class CompositionBaseEnemy : MonoBehaviour
{
    public IEnemy attack;
    public IEnemy dashAttack;
    public IEnemy patrol;

    private void Awake()
    {
        attack = GetComponent<Attack>();
        dashAttack = GetComponent<DashAttack>();
        patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        if (Vector3.Distance(Player.Instance.transform.position, gameObject.transform.position) < 5f)
        {
            attack.Perform(this); //this viittaa aina olioon eli luokan instanssiin
        }
        else
        {
            patrol.Perform(this);
        }
    }
}
