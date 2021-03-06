﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    // Use this for initialization

    void Awake()
    {
        waypoint=GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(),
            0f,
            waypoint.GetGridPos().y * waypoint.GetGridSize()
            );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string textLabel = waypoint.GetGridPos().x+","+waypoint.GetGridPos().y;
        textMesh.text = textLabel;
        gameObject.name = "Cube (" + textLabel + ")";
    }
}
