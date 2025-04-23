using UnityEngine;

public class CoinHybrid : MonoBehaviour
{
    public CoinCollectedEvent coinCollectedEvent; //Aseta inspectorista SO


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        coinCollectedEvent.Raise();
        Destroy(gameObject);
    }

}
