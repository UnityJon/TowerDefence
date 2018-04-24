using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid=new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start () {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping Block at " + gridPos);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        print("Loaded " + grid.Count + "Blocks");
    }
}
