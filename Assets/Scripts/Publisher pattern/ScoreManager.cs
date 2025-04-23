using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int score;

    private void OnEnable()
    {
        GameEvents.OnCoinCollected += UpdateScore;
        GameEvents.OnGameOver += ShowFinalScore;
    }

    private void OnDisable()
    {
        GameEvents.OnCoinCollected -= UpdateScore;
    }


    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log($"Score: {score}");
    }

    void ShowFinalScore()
    {            
        Debug.Log("FINAL SCORE: " + score); //Tämän sijaan voitaisiin enabloida joku score-paneeli, jossa vaikka highscoret yms.

        //Seuraavan toiminnallisuuden voisi hoitaa vastaavasti esim. GameManager (Ei kuulu ScoreManagerille):
        StartCoroutine(ReloadLevel());
        
            
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
