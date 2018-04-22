using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour {


    [SerializeField] [Range(1f, 20f)] float gridSize=10f;
    TextMesh textMesh;

    // Use this for initialization
    void Start () {
	}

    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    void Update()
    {
        Debug.Log("Editor causes this Update");
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = snapPos;
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x/gridSize + "," + snapPos.z/gridSize;
    }
}
