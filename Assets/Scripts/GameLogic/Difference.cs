using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Difference : MonoBehaviour, IPointerClickHandler
{
    private int _Number;

    private GameObject _Marker;

    private GameObject _Particles;
    
    private bool _Is_Found;

    public event Action<int> _On_Finded;
    
    public void Init(Action<int> _action, int _number, GameObject _marker, GameObject _particles)
    {
        _On_Finded += _action;
        
        _Number = _number;
        
        _Marker = _marker;
        
        _Particles = _particles;
    }
    
    public void Find()
    {
        _Is_Found = true;
        
        _Marker.SetActive(true);
        _Particles.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_Is_Found)
            _On_Finded?.Invoke(_Number);
    }
}
