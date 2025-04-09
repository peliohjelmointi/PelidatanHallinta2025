using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] GameObject Level_1;


    private void Start()
    {
        Instantiate(Level_1);
    }
}
