using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grid : Singleton<Grid>
{
    public GameObject[,] gridList;
    public int startX = 2;
    public int startZ = 10;
    public int remainder = 0;
    public int plusX;
    public int plusZ;
    public int currentX;
    public int currentZ;
    private int newSpawnx = 0;
    private int newSpawnz = 0;
    private int offsetX = 1;
    private int offsetZ = 1;
    [SerializeField] private int zSpawnOffset;

    private void Awake()
    {
        gridList = new GameObject[1000, 1000];
        currentX = startX;
        currentZ = startZ;
    }

    private void Start()
    {
        FirstGrid();
    }

    private void FirstGrid()
    {
        var offset = 1f;
        var gridX = startX / 2;
        for (int i = 0; i < startX; i++)
        {
            for (int j = 0; j < startZ; j++)
            {
                Vector3 gridPos = (transform.position + new Vector3(-gridX + 0.5f, 0f, 0f)) +
                                  new Vector3(offset * i, transform.position.y, -offset * j);
                gridList[i, j] = ObjectPool.Instance.GetPooledObject(0);
                gridList[i, j].transform.SetParent(transform);
                gridList[i, j].transform.position = gridPos;
            }
        }
        currentX = startX;
        currentZ = startZ;
    }

    public void GetNewWidth(int number)
    {
        plusX = number;
        for (int i = currentX; i < currentX + plusX; i++)
        {
            for (int j = 0; j < currentZ; j++)
            {
                Vector3 gridPos = gridList[newSpawnx, j].transform.position;
                gridList[i, j] = ObjectPool.Instance.GetPooledObject(0);
                gridList[i, j].transform.SetParent(transform);
                gridList[i, j].transform.position = gridPos;
                if (newSpawnx == 0)
                {
                    var pos =gridList[i, j].transform.position;
                    gridList[i, j].transform.DOLocalMove(
                        new Vector3(pos.x - offsetX, pos.y, pos.z) - transform.position,
                        0.5f);
                }
                else if (newSpawnx != 0)
                {
                    var pos =gridList[i, j].transform.position;
                    gridList[i, j].transform.DOLocalMove(
                        new Vector3(pos.x + offsetX, pos.y, pos.z) - transform.position,
                        0.5f);
                }
               
            }
            switch (newSpawnx)
            {
                case 0 :
                    newSpawnx += 1;
                    break;
                case 1 :
                    newSpawnx = 0;
                    offsetX += 1;
                    break;
            }
        }
        currentX += plusX;
    }

    public void GetNewLength(int number)
    {
        plusZ = number;
        newSpawnz = currentZ - number;
        for (int i = 0; i < currentX; i++)
        {
            offsetZ = 1;
            for (int j = currentZ; j < currentZ + plusZ; j++)
            {
                Vector3 gridPos = gridList[i, newSpawnz].transform.position + new Vector3(0f,0f,-zSpawnOffset);
                var transformToFollow = gridList[i, currentZ - 1].transform;
                gridList[i, j] = ObjectPool.Instance.GetPooledObject(0);
                gridList[i, j].transform.SetParent(transform);
                gridList[i, j].transform.position = gridPos;
                newSpawnz += 1;
                var pos = transformToFollow.position;
                gridList[i, j].transform.DOLocalMove(new Vector3(pos.x,pos.y,pos.z-offsetZ) - transform.position, 1f);
                offsetZ += 1;
            }
            newSpawnz = currentZ - number;
        }
        currentZ += plusZ;
    }
}
