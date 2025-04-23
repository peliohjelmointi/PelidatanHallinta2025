using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDamageable
{
    public void Interact()
    {
       //esim. oven avaaminen/sulkeminen
    }

    public void TakeDamage()
    {
       //esim. halkeaminen, kunnes menee rikki, jos esim. 10x osuttu
    }
}
