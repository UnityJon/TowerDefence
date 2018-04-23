using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;

	// Use this for initialization
	void Start ()
    {
        PrintWaypoints();
    }

    private void PrintWaypoints()
    {
        foreach (Block block in path)
        {
            string text = block.name;
            print(text);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
