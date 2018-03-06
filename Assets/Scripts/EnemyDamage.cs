using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }


    void ProcessHit()
    {
        hitPoints -= 1;//todo change to variable    
        print("Current hit points are " + hitPoints +"points");
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
