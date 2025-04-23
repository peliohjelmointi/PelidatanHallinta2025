using UnityEngine;

public class SoundManager : MonoBehaviour
{
    int score;
    private void OnEnable()
    {
        GameEvents.OnCoinCollected += PlayCollectSound;
        GameEvents.OnGameOver += PlayGameOverTheme;
    }

    void PlayCollectSound(int s)
    {
        Debug.Log("DING!");
    }

    void PlayGameOverTheme()
    {    
        Debug.Log("..playing game over theme music...");                    
    }
}
