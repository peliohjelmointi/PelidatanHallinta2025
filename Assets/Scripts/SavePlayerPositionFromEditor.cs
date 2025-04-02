using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
public class SavePlayerPositionFromEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("SAVE PLAYER POSITION TO SO"))
        {
            Transform player = (Transform)target; //target on aina (klikattu)
                                                  //aktiivinen gameobjekti
            
            //yritetään ladata jo luotu scriptable object, jossa pelaajan positio
            PlayerPositionSO playerPositionData = AssetDatabase.LoadAssetAtPath<PlayerPositionSO>("Assets/PlayerStartPosition.asset");
            if (playerPositionData == null) //tiedostoa ei löytynyt
            {
                //luodaan uusi instanssi playerpositionSO:sta
                playerPositionData = ScriptableObject.CreateInstance<PlayerPositionSO>();              
                
                //luodaan uusi scriptable object                
                AssetDatabase.CreateAsset(playerPositionData, "Assets/PlayerStartPosition.asset");                
            }
            //asetetaan tiedostoon pelaajan positio
            playerPositionData.playerStartPosition = player.position;
            playerPositionData.playerRotation = player.eulerAngles;

            //Lähtökohtaisesti SO:t ei ole tarkoitettu tiedon pysyvään tallentamiseen
            // mutta se on mahdollista seuraavasti:
            EditorUtility.SetDirty(playerPositionData);
            AssetDatabase.SaveAssets();

            Debug.Log("Player position saved to PlayerStartPosition.asset (SO)");
        }
    }
}
