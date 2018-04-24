using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid=new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;


    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartAndEnd();
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
                waypoint.SetTopColor(Color.cyan);
            }
        }
        print("Loaded " + grid.Count + "Blocks");
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.magenta);
    }

}
