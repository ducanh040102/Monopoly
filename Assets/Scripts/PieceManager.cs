using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PieceManager : MonoBehaviour
{
    public List<GameObject> pieceList;
    public List<int> playerTileNumberList;
    public GameObject playPiece;
    public GameObject pieceSpawnpointObject;
    public Button rollDiceButton;

    public int numberOfPlayer = 0;

    public int playerTurn = 0;
    public int step = 0;
    public bool firstPlayerMoved = false;

    private void Start()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            pieceList.Add(GameObject.Instantiate(playPiece, Vector3.zero, gameObject.transform.rotation));
            pieceList[i].transform.position = pieceSpawnpointObject.transform.position;
            playerTileNumberList.Add(1);
        }
    }

    public void MovePiece()
    {
        InvokeRepeating("MoveTileToTile", 0.2f, 0.5f);
    }

    private void MoveTileToTile()
    {
        pieceList[playerTurn].transform.DOMove(TileManager.instance.tiles[playerTileNumberList[playerTurn]].transform.position, 0.3f).SetEase(Ease.InOutCirc);
        step--;
        playerTileNumberList[playerTurn]++;
        if(step == 0)
        {
            CancelInvoke();
            StartCoroutine(WaitForFinishMove(1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ThrowDice.instance.isHaveResult)
        {
            if (firstPlayerMoved)
            {
                playerTurn++;
            }
            if (playerTurn == numberOfPlayer)
            {
                playerTurn = 0;
            }
            InvokeRepeating("MoveTileToTile", 0.2f, 0.5f);
            step = ThrowDice.instance.diceValue;
            ThrowDice.instance.isHaveResult = false;
            firstPlayerMoved = true;
            
        }

        if (playerTileNumberList[playerTurn] >= TileManager.instance.GetTileNumber())
        {
            playerTileNumberList[playerTurn] = 0;
        }
    }
    IEnumerator WaitForFinishMove(float sec)
    {
        yield return new WaitForSeconds(sec);
        rollDiceButton.interactable = true;
        
    }
}
