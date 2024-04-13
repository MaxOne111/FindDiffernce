using System;
using DG.Tweening;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private DOScale _DO_Scale;
    [SerializeField] private Ease _Animation;
    
    public void Show()
    {
        gameObject.SetActive(true);
        
        DOScaleEfffect();
    }

    private void DOScaleEfffect()
    {
        transform.localScale = Vector3.zero;
        
        transform.DOScale(_DO_Scale._End_Value, _DO_Scale._Duration).SetEase(_Animation).SetLink(gameObject);
    }
}

[Serializable]
public struct DOScale
{
    public Vector3 _End_Value;
    public float _Duration;
}