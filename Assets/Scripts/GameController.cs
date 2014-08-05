using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
    public GameObject numberPrefab;

    private int[][] numberArray = new int[4][]{
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0},
        new int[4]{0,0,0,0}
    };

    private Number[][] numCoponentArray = new Number[4][]{
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null},
        new Number[4]{null,null,null,null}
    };

    private void GenerateNumber()
    {
        int numberX = -1;
        int numberY = -1;
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
    flag:
        dfControl numdfControl = this.GetComponent<dfControl>().AddPrefab(numberPrefab);
        Number number = numdfControl.GetComponent<Number>();
        number.number = 1;
        number.positionX = numberX;
        number.positionY = numberY;
        numberArray[numberX][numberY]++;
        numCoponentArray[numberX][numberY] = number;
        return;
    }

}
