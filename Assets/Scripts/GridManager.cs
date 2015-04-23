using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class GridManager : MonoBehaviour {
    public Cell _cellPrefab;
    public GameObject _parent;

    public Vector2Int gridDimensions;
    public float iterationDelay = 1.0f;
    public float activeProbability = 0.15f;
    
    private Cell[,] _cells;

    private bool started = false;

	// Use this for initialization
	void Start () 
    {
        GenerateGrid();        
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RestartGrid();
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            FillRandomly();
        }        

        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                var cell = hit.collider.GetComponent<Cell>();
                cell.setActive();
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!started)
            {
                started = true;
                StartCoroutine("GameIterationCoroutine");
            }
        }
    }

    void ShowNeighbours(Vector2Int location)
    {
        for (int x = location.x - 1; x < location.x + 2; x++)
        {
            for (int y = location.y - 1; y < location.y + 2; y++)
            {
                if (x < 0 || y < 0 || x > (gridDimensions.x - 1) || y > (gridDimensions.y - 1))
                    // estamos fuera del rango del grid
                    continue;

                if (x == location.x && y == location.y)
                    // es la celda actual
                    continue;

                if (_cells[x, y].alive)
                {
                    // la celda está viva, entonces es un vecino de la celda actual
                    _cells[x, y].setNeighbour();
                }
            }
        }
    }

    IEnumerator GameIterationCoroutine()
    {
        while (true && started)
        {
            UpdateNeighboorhood();
            CheckState();

            yield return new WaitForSeconds(iterationDelay);
        }
    }

    public void setModeAndRestart(IRuleStrategy strategy)
    {
        started = false;

        for (int rowCell = 0; rowCell < gridDimensions.x; rowCell++)
        {
            for (int colCell = 0; colCell < gridDimensions.y; colCell++)
            {
                _cells[rowCell, colCell].setDead();
                _cells[rowCell, colCell].strategy = strategy;
            }
        }
    }

    private void CheckState()
    {
        for (int rowCell = 0; rowCell < gridDimensions.x; rowCell++)
        {
            for (int colCell = 0; colCell < gridDimensions.y; colCell++)
            {
                _cells[rowCell, colCell].CheckState();
            }
        }
    }

    private void UpdateNeighboorhood()
    {
        for (int rowCell = 0; rowCell < gridDimensions.x; rowCell++)
        {
            for (int colCell = 0; colCell < gridDimensions.y; colCell++)
            {
                int neighbours = 0;
                for (int x = rowCell - 1; x < rowCell + 2; x++)
                {
                    for (int y = colCell - 1; y < colCell + 2; y++)
                    {
                        if (x < 0 || y < 0 || x > (gridDimensions.x - 1) || y > (gridDimensions.y - 1))
                            // estamos fuera del rango del grid
                            continue;

                        if (x == rowCell && y == colCell)
                            // es la celda actual
                            continue;

                        if (_cells[x, y].alive)
                            // la celda está viva, entonces es un vecino de la celda actual
                            neighbours++;
                    }
                }
                _cells[rowCell, colCell].numberOfNeighbours = neighbours;
            }
        }
    }

    private void RestartGrid()
    {
        started = false;

        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int y = 0; y < gridDimensions.y; y++)
            {
                _cells[x, y].setDead();
            }
        }
    }

    private void FillRandomly()
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int y = 0; y < gridDimensions.y; y++)
            {
                if (UnityEngine.Random.value < activeProbability)
                {
                    _cells[x, y].setActive();
                }
            }
        }
    }

    private void GenerateGrid()
    {
        _cells = new Cell[gridDimensions.x, gridDimensions.y];
        IRuleStrategy conwaysStrategy = new ConwaysRuleStrategy();

        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int y = 0; y < gridDimensions.y; y++)
            {
                var cell = Instantiate(_cellPrefab, new Vector3(x, y, 0), Quaternion.identity) as Cell;
                cell.name = String.Format("Cell ({0}, {1})", x, y);
                cell.transform.localScale *= 0.9f;
                cell.transform.parent = _parent.transform;
                cell.location = new Vector2Int(x, y);
                cell.strategy = conwaysStrategy;

                //if(UnityEngine.Random.value < activeProbability)
                //{
                    //cell.setActive();
                //}

                _cells[x, y] = cell;
            }
        }
    }	
}

[Serializable]
public struct Vector2Int
{
    public int x;
    public int y;

    public Vector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public enum Modo
{
    Conways,
    Caos,
    Replicas,
    Amebas,
    HighLife,
    DiffusionRule,
    Muerte,
    Vida34,
    LongLife
}