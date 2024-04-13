using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableLevelLoader : MonoBehaviour
{
    [SerializeField] private AssetReference _Level;

    private AsyncOperationHandle _Handle;

    public event Action _On_Level_Loaded;
    private void Start() => StartCoroutine(Load());

    private IEnumerator Load()
    {
        if (_Handle.IsValid())
            Addressables.Release(_Handle);

        _Handle = _Level.LoadAssetAsync<GameObject>();
        yield return _Handle;
        SceneMediator.LoadLevel(_Handle.Result as GameObject);
            
        _On_Level_Loaded?.Invoke();
    }
}