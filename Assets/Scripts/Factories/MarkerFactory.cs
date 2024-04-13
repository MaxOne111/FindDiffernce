using UnityEngine;

public class MarkerFactory : GenericFactory<GameObject>
{
    public override GameObject GetInstance(Transform _parent)
    {
        GameObject _marker = Instantiate(_Prefab, _parent);
        _marker.SetActive(false);

        return _marker;
    }
}