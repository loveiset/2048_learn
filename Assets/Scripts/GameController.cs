using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameStat
{
    Playing,
    Pause,
    End
}

public enum TouchDir
{
    Left,
    Right,
    Bottom,
    Top,
    None
}

public class GameController : MonoBehaviour 
{
    public GameObject numberPrefab;
    public GameStat state = GameStat.Playing;
    private Vector3 mouseDownPosition;
    public static GameController _instance;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
        GenerateNumber();
    }

    void Update()
    {
        switch (state)
        {
            case GameStat.Playing:
                MoveNumber();
                break;
            case GameStat.Pause:
                break;
            case GameStat.End:
                break;
        }
    }

    public int[][] numberArray = new int[4][]{
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0}
    };

    public Number[][] numCoponentArray = new Number[4][]{
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null}
    };

    private void GenerateNumber(int posX = -1, int posY = -1, int numberToCreate = 1, float tweenInDelay = 0.0f)
    {
        int numberX = -1;
        int numberY = -1;
        if (posX == -1 || posY == -1)
        {
            int countOfEmptyNumber = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (numberArray[x][y] == 0)
                    {
                        countOfEmptyNumber++;
                    }
                }
            }
            if (countOfEmptyNumber == 0)
            {
                return;
            }

            int randomNum = Random.Range(1, countOfEmptyNumber + 1);
            int index = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (numberArray[x][y] == 0)
                    {
                        index++;
                        if (index == randomNum)
                        {
                            numberX = x;
                            numberY = y;
                            goto flag;
                        }
                    }
                }
            }
        }
        else
        {
            numberX = posX;
            numberY = posY;
        }
    flag:
        dfControl numdfControl = this.GetComponent<dfControl>().AddPrefab(numberPrefab);
        Number number = numdfControl.GetComponent<Number>();
        number.number = numberToCreate;
        number.positionX = numberX;
        number.positionY = numberY;
        number.SetTweenDelay(tweenInDelay);
        numberArray[numberX][numberY]++;
        numCoponentArray[numberX][numberY] = number;
        return;
    }

    private bool CheckWin()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (numberArray[x][y] != 0)
                {
                    if (numCoponentArray[x][y].number == 13)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool CheckGameOver()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (numberArray[x][y] == 0)
                {
                    return false;
                }
            }
        }

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (numCoponentArray[x][y].number == numCoponentArray[x][y+1].number)
                {
                    return false;
                }
            }
        }

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (numCoponentArray[x][y].number == numCoponentArray[x+1][y].number)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void MoveNumber()
    {
        bool isAnyNumberMove = false;
        int countCombine = 0;
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) == false)
        {
            return;
        }
        TouchDir touchDir = GetTouchDir();
        switch (touchDir)
        {
            case TouchDir.None:
                return;
            case TouchDir.Left:
                for (int y = 0; y < 4; y++)
                {
                    Number preNumber = null;
                    int index = -1;
                    for (int x = 0; x < 4; x++)
                    {
                        if (numberArray[x][y] == 0)
                        {
                            continue;
                        }
                        if (preNumber == null)
                        {
                            preNumber = numCoponentArray[x][y];
                            index++;
                        }
                        else
                        {
                            if (preNumber.number == numCoponentArray[x][y].number)
                            {
                                GenerateNumber(index, y, preNumber.number + 1, 0.5f);
                                countCombine++;
                                preNumber.Disappear();
                                numCoponentArray[x][y].Disappear();

                                preNumber = null;
                            }
                            else
                            {
                                preNumber = numCoponentArray[x][y];
                                index++;
                            }
                        }

                        if (numCoponentArray[x][y].MoveToPosition(index, y))
                        {
                            isAnyNumberMove = true;
                        }
                    }
                }
                break;
            case TouchDir.Right:
                for (int y = 0; y < 4; y++)
                {
                    Number preNumber = null;
                    int index = 4;
                    for (int x = 3; x >= 0; x--)
                    {
                        if (numberArray[x][y] == 0)
                        {
                            continue;
                        }
                        if (preNumber == null)
                        {
                            preNumber = numCoponentArray[x][y];
                            index--;
                        }
                        else
                        {
                            if (preNumber.number == numCoponentArray[x][y].number)
                            {
                                GenerateNumber(index, y, preNumber.number + 1,0.5f);
                                countCombine++;
                                preNumber.Disappear();
                                numCoponentArray[x][y].Disappear();

                                preNumber = null;
                            }
                            else
                            {
                                preNumber = numCoponentArray[x][y];
                                index--;
                            }
                        }
                        if (numCoponentArray[x][y].MoveToPosition(index, y))
                        {
                            isAnyNumberMove = true;
                        }
                    }
                }
                    break;
            case TouchDir.Top:
                    for (int x = 0; x < 4; x++)
                    {
                        Number preNumber = null;
                        int index = -1;
                        for (int y = 0; y < 4; y++)
                        {
                            if (numberArray[x][y] == 0)
                            {
                                continue;
                            }
                            if (preNumber == null)
                            {
                                preNumber = numCoponentArray[x][y];
                                index++;
                            }
                            else
                            {
                                if (preNumber.number == numCoponentArray[x][y].number)
                                {
                                    GenerateNumber(x, index, preNumber.number + 1, 0.5f);
                                    countCombine++;
                                    preNumber.Disappear();
                                    numCoponentArray[x][y].Disappear();

                                    preNumber = null;
                                }
                                else
                                {
                                    preNumber = numCoponentArray[x][y];
                                    index++;
                                }
                            }
                            if (numCoponentArray[x][y].MoveToPosition(x, index))
                            {
                                isAnyNumberMove = true;
                            }
                        }
                    }
                break;
            case TouchDir.Bottom:
                for (int x = 0; x < 4; x++)
                {
                    Number preNumber = null;
                    int index = 4;
                    for (int y = 3; y >= 0; y--)
                    {
                        if (numberArray[x][y] == 0)
                        {
                            continue;
                        }
                        if (preNumber == null)
                        {
                            preNumber = numCoponentArray[x][y];
                            index--;
                        }
                        else
                        {
                            if (preNumber.number == numCoponentArray[x][y].number)
                            {
                                GenerateNumber(x, index, preNumber.number + 1, 0.5f);
                                countCombine++;
                                preNumber.Disappear();
                                numCoponentArray[x][y].Disappear();

                                preNumber = null;
                            }
                            else
                            {
                                preNumber = numCoponentArray[x][y];
                                index--;
                            }
                        }
                        if (numCoponentArray[x][y].MoveToPosition(x, index))
                        {
                            isAnyNumberMove = true;
                        }
                    }
                }
                break;
        }

        if (countCombine > 0)
        {
            audio.Play();
        }
        if (isAnyNumberMove)
        {
            GenerateNumber();
        }
    }

    private TouchDir GetTouchDir()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 touchOffset = Input.mousePosition - mouseDownPosition;
            if (Mathf.Abs(touchOffset.x) < Mathf.Abs(touchOffset.y) && Mathf.Abs(touchOffset.y) > 50)
            {
                if (touchOffset.y < 0)
                {
                    return TouchDir.Bottom;
                }
            }

            if (Mathf.Abs(touchOffset.x) < Mathf.Abs(touchOffset.y) && Mathf.Abs(touchOffset.y) > 50)
            {
                if (touchOffset.y > 0)
                {
                    return TouchDir.Top;
                }
            }

            if (Mathf.Abs(touchOffset.x) > Mathf.Abs(touchOffset.y) && Mathf.Abs(touchOffset.x) > 50)
            {
                if (touchOffset.x < 0)
                {
                    return TouchDir.Left;
                }
            }

            if (Mathf.Abs(touchOffset.x) > Mathf.Abs(touchOffset.y) && Mathf.Abs(touchOffset.x) > 50)
            {
                if (touchOffset.x > 0)
                {
                    return TouchDir.Right;
                }
            }
        }
        return TouchDir.None;
    }

}
