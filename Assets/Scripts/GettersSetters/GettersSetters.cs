using UnityEngine;

public class GettersSetters : MonoBehaviour
{
    private int x = 5; // ei n�y muihin skripteihin
    public int X //n�kyy kaikkialle
    {
        get
        {           
            Debug.Log("Getteri� kutsuttiin");
            return x;
        }
        private set
        {
            Debug.Log("X:n arvoa asetaan setterist�");
            x = value;
        }
    }

    private int y = 1;
    public int Y { get { return y; } set { } }

    private int z = 10;
    public int Z => z;

    private int health;
    public int Health
    {
        get => health;
        set => health = Mathf.Max(0, value);
    }

 
    public int Secret { get; private set; }


    void PrintHelloWorld()
    {
        print("HELLO WOLRD!");
        
    }


}

