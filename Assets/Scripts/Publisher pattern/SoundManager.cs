using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnCoinCollected += PlayCollectSound;
        GameEvents.OnGameOver += PlayGameOverTheme;
    }



    public void PlayCollectSound(int s)
    {
        Debug.Log("DING!");
    }

    void PlayGameOverTheme()
    {    
        Debug.Log("..playing game over theme music...");                    
    }
}


