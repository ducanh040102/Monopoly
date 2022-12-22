using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public static Piece instance;

    private void Awake()
    {
        instance = this;
    }
}
