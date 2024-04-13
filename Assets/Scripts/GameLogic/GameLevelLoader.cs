using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameLevelLoader : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(SceneMediator.Level);
        
        LoadLevel();
        
    }

    private void LoadLevel() => Instantiate(GetLevel());

    private GameObject GetLevel() => SceneMediator.Level;
}