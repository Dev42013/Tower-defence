using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

    [SerializeField] Color exploredColor;

    public bool isExplored = false; // ok as is a data class
    public WayPoint exploredFrom;

    Vector2Int gridPos;

    const int gridSize = 10;

    // Use this for initialization
    void Start () {

	}
	
    public int GetGridSize()
    {
        return gridSize;
    }

    // consider setting own color in Update()

    void Update()
    {
        if (exploredFrom != null)
        {
            exploredFrom.SetTopColor(Color.blue);  // todo move later
        }
        
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

	public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
