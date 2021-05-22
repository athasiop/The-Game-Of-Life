using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int alive = 1;
    Renderer ren;
    float timer=1f;
    bool moveGen = false;
    List<Transform> neighbours = new List<Transform>();
    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }
    private void Start()
    {
        Collider[] col = Physics.OverlapBox(transform.position, new Vector3(1.2f, 1.2f, 1.2f));
        foreach(Collider c in col)
        {
            neighbours.Add(c.transform);
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            moveGen = !moveGen;
        }
        if (moveGen&&timer<=0)
        {
            timer = GetComponentInParent<GameOfLife>().rate;
            GameLogic();
        }
        if (alive == 1)
        {
            ren.material.color = Color.blue;
        }
        else
        {
            ren.material.color = Color.black;
        }
    }
    void GameLogic()
    {
        
        int countAlive = 0;
        foreach(Transform t in neighbours)
        {
            if (t.transform.GetComponent<Block>().alive == 1)
            {
                countAlive++;
            }            
        }
        if (alive == 1 && (countAlive == 2 || countAlive == 3))
        {
            alive = 1;
        }
        else if (alive == 0 && countAlive == 3)
        {
            alive = 1;
        }
        else
        {
            alive = 0;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1.2f, 1.2f, 1.2f));
    }
}

