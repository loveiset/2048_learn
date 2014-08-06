using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Number : MonoBehaviour 
{
    public int number = 0;
    public int positionX = 0, positionY = 0;
    public Vector2 posOffset = Vector2.zero;

    public dfTweenVector2 tweenIn;
    public dfTweenVector2 tweenOut;
    public dfTweenVector3 tweenMove;

    private bool isDisappear = false;

    void Start()
    {
        InitShow();
        InitPosition();

        tweenMove.TweenCompleted += this.OnTweenMoveCompleted;
        tweenOut.TweenCompleted += this.OnTweenOutCompleted;
    }

    private void InitPosition()
    {
        this.GetComponent<dfControl>().RelativePosition = new Vector3(positionX * 108 + posOffset.x, positionY * 108 + posOffset.y, 0);
    }

    private void InitShow()
    {
        int x = 0, y = 0;
        switch (number)
        {
            case 1:
                x = 1;
                y = 2;
                break;
            case 2:
                x = 1;
                y = 1;
                break;
            case 3:
                x = 2;
                y = 0;
                break;
            case 4:
                x = 2;
                y = 1;
                break;
            case 5:
                x = 1;
                y = 3;
                break;
            case 6:
                x = 0;
                y = 3;
                break;
            case 7:
                x = 2;
                y = 4;
                break;
            case 8:
                x = 2;
                y = 2;
                break;
            case 9:
                x = 0;
                y = 1;
                break;
            case 10:
                x = 2;
                y = 3;
                break;
            case 11:
                x = 0;
                y = 2;
                break;
            case 12:
                x = 1;
                y = 0;
                break;
            case 13:
                x = 0;
                y = 0;
                break;
        }

        this.GetComponent<dfTiledSprite>().TileScroll = new Vector2(0.33f * x, 0.163f * y);
    }

    public void MoveToPosition(int targetX, int targetY)
    {
        GameController._instance.numberArray[targetX][targetX]++;
        GameController._instance.numCoponentArray[targetX][targetY] = this;
        tweenMove.EndValue = new Vector3(targetX * 108 + posOffset.x, targetY * 108 + posOffset.y, 0);
        tweenMove.Play();
    }

    public void Disappear()
    {
        isDisappear = true;
    }

    public void OnTweenMoveCompleted(dfTweenPlayableBase sender)
    {
        if (isDisappear)
        {
            tweenOut.Play();
        }
    }

    public void OnTweenOutCompleted(dfTweenPlayableBase sender)
    {
        Destroy(this.gameObject);
    }

}
