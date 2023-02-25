using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public GameObject[] tiles;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    public int GetTileNumber()
    {
        return tiles.Length;
    }
}
