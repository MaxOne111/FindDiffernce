using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _Picture_Orig;
    [SerializeField] private Transform _Picture_Dif;
    
    private List<Difference> _Differences_On_Picture_Orig = new List<Difference>();
    private List<Difference> _Differences_On_Picture_Dif = new List<Difference>();

    public int Count => _Differences_On_Picture_Dif.Count;

    private MarkerFactory _Marker_Factory;
    private ParticlesFactory _Particles_Factory;
    
    private int _Max_Count = 0;
    private int _Current_Count = 0;

    private void Awake()
    {
        _Marker_Factory = FindObjectOfType<MarkerFactory>();
        _Particles_Factory = FindObjectOfType<ParticlesFactory>();
    }

    private void Start() => Init();

    private void Init()
    {
        LoadDifferences();
        InitDifferences();
    }
    
    private void LoadDifferences()
    {
        for (int i = 0; i < _Picture_Orig.childCount; i++)
        {
            if (_Picture_Orig.GetChild(i).TryGetComponent(out Difference _difference))
                _Differences_On_Picture_Orig.Add(_difference);
        }
        
        for (int i = 0; i < _Picture_Dif.childCount; i++)
        {
            if (_Picture_Dif.GetChild(i).TryGetComponent(out Difference _difference))
                _Differences_On_Picture_Dif.Add(_difference);
        }

        if (_Differences_On_Picture_Orig.Count != _Differences_On_Picture_Dif.Count)
            Debug.LogError("The number of differences in both pictures should be the same");
    }
    
    private void InitDifferences()
    {
        for (int i = 0; i < _Differences_On_Picture_Orig.Count; i++)
        {
            GameObject _marker = _Marker_Factory.GetInstance(_Differences_On_Picture_Orig[i].transform);
            GameObject _particles = _Particles_Factory.GetInstance(_Differences_On_Picture_Orig[i].transform.position,
                Quaternion.identity);
            
            _Differences_On_Picture_Orig[i].Init(OnFinded,i, _marker, _particles);
        }
        
        for (int i = 0; i < _Differences_On_Picture_Dif.Count; i++)
        {
            GameObject _marker = _Marker_Factory.GetInstance(_Differences_On_Picture_Dif[i].transform);
            GameObject _particles = _Particles_Factory.GetInstance(_Differences_On_Picture_Dif[i].transform.position,
                Quaternion.identity);

            _Differences_On_Picture_Dif[i].Init(OnFinded,i, _marker, _particles);
        }
        
        _Max_Count = _Differences_On_Picture_Dif.Count;
    }

    private void OnFinded(int _number)
    {
        _Differences_On_Picture_Orig[_number].Find();
        _Differences_On_Picture_Dif[_number].Find();
        
        _Current_Count++;

        if (_Current_Count == _Max_Count)
            GameEvents.PlayerWin();
    }
    
}