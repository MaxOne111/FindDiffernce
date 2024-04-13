using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _Minutes;
    [Range(0,60)]
    [SerializeField] private int _Seconds;

    private bool _Is_Active = true;
    
    public event Action<int, int> _On_Time_Changed;

    private void OnEnable() => GameEvents._On_Player_Winned += StopTimer;

    private void Start() => StartCoroutine(TimerCountdown());

    private IEnumerator TimerCountdown()
    {
        while (_Minutes > 0 || _Seconds > 0)
        {
            if (!_Is_Active)
                yield break;

            yield return new WaitForSeconds(1f);

            if (_Seconds <= 0)
            {
                _Seconds = 60;
                _Minutes--;
            }
            
            _Seconds--;
            
            _On_Time_Changed?.Invoke(_Seconds,_Minutes);

            yield return null;
        }
        
        yield return new WaitForSeconds(1f);
        
        TimeOver();
    }

    private void StopTimer() => _Is_Active = false;

    private void TimeOver()
    {
        _Minutes = 0;
        _Seconds = 0;
        
        GameEvents.TimeOver();
    }

    private void OnDisable() => GameEvents._On_Player_Winned -= StopTimer;
}