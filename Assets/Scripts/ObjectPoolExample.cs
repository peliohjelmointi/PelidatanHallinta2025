using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolExample : MonoBehaviour
{
    public GameObject cube;      // mitä spawnataan
    public Transform spawnPoint; // mihin spawnataan
    public float spawnRate = 0.1f; //0.1 sek välein spawnaus
    public float fallSpeed = 5f;

    //object pool asetuksia
    public int defaultCapacity = 10; //instansioidaan etukäteen 10 (tässä) cubea
    public int maxCapacity = 20; //montako max yht'aikaa poolissa

    IObjectPool<GameObject> objectPool;

    private void Awake()
    {
        //initialisoidaan objectPool
        objectPool = new ObjectPool<GameObject>(
            CreateObject,          // Funktio, jolla spawnataan objekteja (cube)
            OnObjectGet,           // Funktio, joka ajetaan, kun objekti otetaan poolista, 
            OnObjectRelease,       // Funktio, joka ajetaan, kun objekti palautetaan pooliin
            OnObjectDestroy,       // Funktio, joka ajetaan, kun objekti tuhotaan
            collectionCheck: true, // varmistaa, ettei tule muistivuotoja tai vääriä "stateja"
            defaultCapacity: defaultCapacity, // montako objektia pre-instantioidaan muistiin
            maxSize: maxCapacity         // montako objektia maksimissaan poolissa voi olla
            );
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            SpawnCubes();
    }

    void SpawnCubes()
    {
        GameObject obj = objectPool.Get(); //otetaan poolista objekti jos mahdollista
        obj.transform.position = spawnPoint.position;
        obj.SetActive(true);
        StartCoroutine(DropObject(obj));
    }

    IEnumerator DropObject(GameObject obj)
    {
        while (obj.transform.position.y > 0f)
        {
            // niin kauan kuin y> 0
            obj.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null; // odottaa seuraavaa framea, sitten poistuu
        }
        // jos objektin y <= 0f 
        obj.SetActive(false);
        objectPool.Release(obj); //palauttaa objektin takaisin pooliin
    }


    GameObject CreateObject()
    {
        return Instantiate(cube);
    }

    void OnObjectGet(GameObject obj)
    {
        obj.SetActive(true);
    }
    void OnObjectRelease(GameObject obj)
    {
        obj.SetActive(false);
    }
    void OnObjectDestroy(GameObject obj)
    {
        Destroy(obj);
    }


}
