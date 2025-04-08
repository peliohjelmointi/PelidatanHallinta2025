using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    int points;

    private void Awake()
    {
        //PlayerPrefs.SetInt("lastScore", 1000);
    }

    private void Start()
    {
        points = PlayerPrefs.GetInt("lastScore");
        print(points);

        print("PLAYER:" + PlayerPrefs.GetString("Player")); 
    }
}
