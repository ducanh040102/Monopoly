using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tile : MonoBehaviour
{
    private void OnMouseDown()
    {
        Piece.instance.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutCirc);
    }
}
