﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = {Vector2Int.up,Vector2Int.right,Vector2Int.down,Vector2Int.left};
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Queue<Vector2Int> queue = new Queue<Vector2Int>();
    bool isRunning = true;
    private List<Waypoint> path=new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd(); // ToDo : Prob shouldnt be here
        BreadthFirstSearch();
        CreatePath();
        return path;
    }


    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.previousWaypoint;
        while (previous!=startWaypoint)
        {
            path.Add(previous);
            previous = previous.previousWaypoint;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        isRunning = true;
        queue.Clear();
        queue.Enqueue(startWaypoint.GetGridPos());
        startWaypoint.isExplored = true;
        Vector2Int target = endWaypoint.GetGridPos();
        while (queue.Count > 0 && isRunning)
        {
            Vector2Int searchCentre = queue.Dequeue();
            if (searchCentre == target)
            {
                isRunning = false;
                print("End point found");
                return;
            }
            ExploreNeighbours(searchCentre);
        }
        print("End point not found!");
    }

    private void ExploreNeighbours(Vector2Int from)
    {
        Vector2Int checkNext;
        foreach (Vector2Int direction in directions) {
            checkNext = from + direction;
            if (grid.ContainsKey(checkNext)) {
                if (!grid[checkNext].isExplored)
                {
                    queue.Enqueue(checkNext);
                    grid[checkNext].isExplored = true;
                    grid[checkNext].previousWaypoint = grid[from];
                }
            }
        }
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

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.magenta);
    }

}
