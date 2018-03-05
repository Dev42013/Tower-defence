using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    [SerializeField] List<WayPoint> path;

	// Use this for initialization
	void Start () {     
        //StartCoroutine(FollowPath());
	}

    IEnumerator FollowPath()
    {
        print("Starting Patrol");
        foreach (WayPoint wp in path)
        {
            transform.position = wp.transform.position;
            print("Visiting block: " + wp);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update () {
		
	}



}
