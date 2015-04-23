using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public bool alive { get; set; }
    public Vector2Int location { get; set; }
    public int numberOfNeighbours { get; set; }

    void Start()
    {
        numberOfNeighbours = 0;
    }
    
    public void CheckState()
    {
        if (alive)
        {
            if (numberOfNeighbours < 2)
                setDead();
            else if (numberOfNeighbours > 3)
                setDead();
        }
        else
        {
            if (numberOfNeighbours == 3)
                setActive();
        }
    }

    public void setActive()
    {
        alive = true;
        GetComponent<Renderer>().material.color = Color.gray;
    }

    public void setNeighbour()
    {
        alive = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }
    
    public void setDead()
    {
        alive = false;
        GetComponent<Renderer>().material.color = Color.white;
    }
}

