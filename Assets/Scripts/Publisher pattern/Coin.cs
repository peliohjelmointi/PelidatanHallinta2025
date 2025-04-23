using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinSO coinSO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

   public void CollectCoin()
    {
        GameEvents.OnCoinCollected?.Invoke(coinSO.coinValue);
        Destroy(gameObject);
    }
}
