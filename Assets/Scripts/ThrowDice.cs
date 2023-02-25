using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ThrowDice : MonoBehaviour
{
    public static ThrowDice instance;
    public GameObject rollDiceBtn;
    public int diceValue = 0;
    public float waitForResult = 1.5f;
    public bool isHaveResult = false;
    public bool diceRolled = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(!Dice.rolling && diceRolled) {
            StartCoroutine(TakeDiceResult());
            diceRolled = false;
        }
    }

    public void ThrowTheDice()
    {
        diceRolled = true;
        rollDiceBtn.GetComponent<Button>().interactable = false;
        Dice.Clear();
        Dice.Roll("1d6", "d6-" + randomColor, transform.position, Force());
        Dice.Roll("1d6", "d6-" + randomColor, transform.position, Force());
        //StartCoroutine(TakeDiceResult());
        
    }

    void OnGUI()
    {
        if (Dice.Count("") > 0)
        {
            // we have rolling dice so display rolling status
            GUI.Box(new Rect(10, Screen.height - 75, Screen.width - 20, 30), "");
            GUI.Label(new Rect(20, Screen.height - 70, Screen.width, 20), Dice.AsString(""));
        }
    }

    private Vector3 Force()
    {
        Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
        return Vector3.Lerp(transform.position, rollTarget, 1).normalized * (-50 - Random.value * 60);
    }

     IEnumerator TakeDiceResult()
    {
        yield return new WaitForSeconds(waitForResult);
        diceValue = Dice.Value("d6");
        isHaveResult = true;
        
    }

    string randomColor
    {
        get
        {
            string _color = "blue";
            int c = System.Convert.ToInt32(Random.value * 6);
            switch (c)
            {
                case 0: _color = "red"; break;
                case 1: _color = "green"; break;
                case 2: _color = "blue"; break;
                case 3: _color = "yellow"; break;
                case 4: _color = "white"; break;
                case 5: _color = "black"; break;
            }
            return _color;

        }
    }
}