using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFinder : MonoBehaviour {

    [SerializeField] WayPoint startWayPoint, endWayPoint;

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool queueIsRunning = true;  
    WayPoint searchCenter;
    List<WayPoint> path = new List<WayPoint>(); 


    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();

        return path;
    }

    private void CreatePath()
    {
        path.Add(endWayPoint);

        WayPoint previous = endWayPoint.exploredFrom;

        while (previous != startWayPoint)
        {
            // add intermediate waypoints
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        // add start waypoint
        path.Add(startWayPoint);
        // reverse the list
        path.Reverse();

    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && queueIsRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {

        if (searchCenter == endWayPoint)
        {
            queueIsRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!queueIsRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeigbours(neighbourCoordinates);
            }          
        }
    }

    private void QueueNewNeigbours(Vector2Int neighbourCoordinates)
    {
        WayPoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {       
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
       
    }

    private void ColorStartAndEnd()
    {
        // todo consider moving it
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();

        foreach (WayPoint waypoint in waypoints)
        {

            var gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos);

            if (isOverlapping)
            {
                Debug.Log("Warning overlapping blocks: " + waypoint);
            } else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        // print("Loaded: " + grid.Count + " blocks");
    }

}
