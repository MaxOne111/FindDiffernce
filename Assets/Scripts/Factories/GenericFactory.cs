using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T: Object
{
    [SerializeField] protected T _Prefab;

    public virtual T GetInstance(Vector3 _position, Quaternion _rotation) => Instantiate(_Prefab, _position, _rotation);
    public virtual T GetInstance(Transform _parent) => Instantiate(_Prefab, _parent);
}