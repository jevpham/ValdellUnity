using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBattleMap : MonoBehaviour
{

    public GameObject hexagonPrefab;

    int width = 5;
    int height = 5;

    float XOffSet = (float)System.Math.Sqrt(0.75f);
    float YOffSet = 0.75f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPosition = x * XOffSet;

                if (y % 2 == 1)
                {
                    xPosition += XOffSet / 2f;

                }
                GameObject hexagon_go = (GameObject)Instantiate(hexagonPrefab, new Vector3(xPosition, y * YOffSet, 0), Quaternion.identity);

                hexagon_go.name = "Hexagon_" + x + "_" + y;
                hexagon_go.transform.SetParent(this.transform);

            }
        }
    }






}
