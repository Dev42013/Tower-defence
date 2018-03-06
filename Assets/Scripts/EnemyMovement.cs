using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	void Start () {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<WayPoint> path)
    {
        print("Starting Patrol");
        foreach (WayPoint wp in path)
        {
            transform.position = wp.transform.position;
            yield return new WaitForSeconds(2f);
        }
        print("Ending Patrol");
    }

}
