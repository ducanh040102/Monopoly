using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int[] DiceValues;
    public int DiceTotal;

    // Start is called before the first frame update
    void Start()
    {
        DiceValues = new int[2];
    }

    void Update()
    {
        
    }

    public void RollDices()
    {
        DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(1, 7);
            DiceTotal += DiceValues[i];
        }

        Debug.Log(DiceTotal);
    }
}
