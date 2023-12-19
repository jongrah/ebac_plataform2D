using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .1f;

    private Tween _currentTween;

    private void OnValidate()
    {
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Flash();
        }
    }


    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach(var s in spriteRenderers)
        {
            s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }

}
