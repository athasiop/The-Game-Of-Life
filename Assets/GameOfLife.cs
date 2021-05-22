using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    [SerializeField]
    GameObject block;
    [SerializeField]
    Vector2 gridSize;
    
    public float rate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        for(int i=0;i< (int)gridSize.x; i++)
        {
            for(int j=0;j< (int)gridSize.y; j++)
            {
                Instantiate(block, new Vector3(i, 0, j), Quaternion.identity, transform);
            }
        }
        foreach(Transform t in transform)
        {
            t.GetComponent<Block>().alive = 0;
        }
    }
    
}
