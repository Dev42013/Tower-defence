using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    [SerializeField] List<WayPoint> path;

	// Use this for initialization
	void Start () {
        PrintAllWaypoints();
	}

    private void PrintAllWaypoints()
    {
        foreach (WayPoint wp in path)
        {
            print(wp.name);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}



}
