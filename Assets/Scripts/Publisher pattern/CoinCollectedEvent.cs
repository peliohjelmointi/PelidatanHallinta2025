using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CoinCollectedEvent", menuName = "Scriptable Objects/CoinCollectedEvent")]
public class CoinCollectedEvent : ScriptableObject
{
    // toimii myös public UnityAction (jolloin toiminnallisuus
    // täytyy asettaa koodista. Kevyempi kuin UnityEvent
    public UnityEvent OnEventRaised;


    public void Raise()
    {
        OnEventRaised?.Invoke();
    }
}
