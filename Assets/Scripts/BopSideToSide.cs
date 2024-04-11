using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BopSideToSide : MonoBehaviour
{

    void Start()
    {
        var sequence = DOTween.Sequence()
                .Append(transform.DOScale(0.1f, 0.4f).SetRelative())
                .Join(transform.DORotate(new Vector3(0,0,10), 0.4f).SetRelative())
                .Append(transform.DOScale(-0.1f, 0.2f).SetRelative())
                .Join(transform.DORotate(new Vector3(0,0,-20), 0.4f).SetRelative())
                .Append(transform.DORotate(new Vector3(0,0,10), 0.4f).SetRelative());
            sequence.SetLoops(-1, LoopType.Restart);
    }
}
