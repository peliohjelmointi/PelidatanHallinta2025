using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Button SaveButton;
    Button LoadButton;
    Button ScreenshotButton;
    
    Sprite screenshot;

    private void Awake()
    {
        SaveButton = transform.Find("SAVE").transform.GetComponent<Button>(); //toimii, mutta jos esim. nimeä vaihtaa, niin huono ratkaisu
        LoadButton = transform.Find("LOAD").transform.GetComponent<Button>();
        
        ScreenshotButton = transform.Find("SCREENSHOT").transform.GetComponent<Button>();
        
        screenshot = Resources.Load<Sprite>("Screenshot");
        
        ScreenshotButton.GetComponent<Image>().sprite = screenshot;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) //Save
        {
            if (SaveButton != null)
            {
                SimulateClick(SaveButton);
            }
    
        }
        if (Input.GetKeyDown(KeyCode.F9)) //Load
        {
            if (LoadButton != null)
            {
                SimulateClick(LoadButton);
            }
        }
    }

    public void SimulateClick(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
        button.onClick.Invoke();


        //Sprite kuva = Resources.Load<Sprite>("Screenshot");

        // ASETA KUVA TYHJÄN KUVAN SPRITEKSI KUN PELI KÄYNNISTETÄÄN
        // JA HETI KUN PELI ON TALLENNETTU
    }

    private void OnApplicationQuit()
    {
        //SaveGame();
    }
}
