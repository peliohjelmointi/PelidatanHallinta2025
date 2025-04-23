using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CoinCollectedEvent", menuName = "Scriptable Objects/CoinCollectedEvent")]
public class CoinCollectedEvent : ScriptableObject
{
    // toimii my�s public UnityAction (jolloin toiminnallisuus
    // t�ytyy asettaa koodista. Kevyempi kuin UnityEvent
    public UnityEvent OnEventRaised;


    public void Raise()
    {
        OnEventRaised?.Invoke();
    }
}
