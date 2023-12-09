using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell _mazeCellPrefab;


    public int _mazeWidth;

    public int _mazeDepth;

    [SerializeField]
    private GameObject _chest;

    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private int _coinCount;

    [SerializeField]
    private int _obstacleCount;

    [SerializeField]
    private GameObject _key;

    [SerializeField]
    private GameObject _obstacle;

    private MazeCell[,] _mazeGrid;


    void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int z = 0; z < _mazeDepth; z++)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity,transform);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);
        OpenEnterAndExit();
        CreateChest();
        CreateCoins();
        CreateKey();
        CreateObstacles();
    }
    private void CreateKey()
    {
        Instantiate(_key, _mazeGrid[Random.Range(1, _mazeWidth - 1), Random.Range(1, _mazeDepth - 1)].gameObject.transform.position + Vector3.up * .2f, Quaternion.Euler(-50, 0, 0));
    }
    private void OpenEnterAndExit()
    {
        _mazeGrid[_mazeWidth - 1, _mazeDepth - 1].FrontWall().SetActive(false);
        _mazeGrid[0, 0].BackWall().SetActive(false);
    }
    private void CreateChest()
    {
        Instantiate(_chest, _mazeGrid[_mazeWidth - 1, _mazeDepth - 1].gameObject.transform.position + new Vector3(0, .2f, 2f), Quaternion.Euler(0, -180, 0));

    }
    private void CreateCoins()
    {
        GameObject coinsObject = new GameObject("Coins");
        for (int i = 0; i < _coinCount; i++)
        {
            Instantiate(_coin, _mazeGrid[Random.Range(1, _mazeWidth - 1), Random.Range(1, _mazeDepth - 1)].gameObject.transform.position + Vector3.up * .2f, Quaternion.Euler(0, 0, 0),coinsObject.transform) ;

        }

    }
    private void CreateObstacles()
    {
        GameObject obstaclesObject = new GameObject("Obstacles");

        for (int i = 0; i < _obstacleCount; i++)
        {
            Instantiate(_obstacle, _mazeGrid[Random.Range(1, _mazeWidth - 1), Random.Range(1, _mazeDepth - 1)].gameObject.transform.position + Vector3.up * -.22f, Quaternion.Euler(0, 0, 0),obstaclesObject.transform);

        }

    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }



}
