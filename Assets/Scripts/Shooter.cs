using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start () {
		
		animator = GameObject.FindObjectOfType<Animator> ();

		//Creates Parent if necessary
		projectileParent = GameObject.Find ("Projectiles");
		if (projectileParent == null)
		{
			projectileParent = new GameObject("Projectiles");
		}

		//Finds if Spawner exists in the same y coordinate.
		SetMyLaneSpawner();
		print (myLaneSpawner);
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	void Update()
	{
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//Attackers in lane but behind us (transform.position.x)
		return false;
	}

	void SetMyLaneSpawner() {
		Spawner[] spawnArray = GameObject.FindObjectsOfType<Spawner> ();

		float myYPos = transform.position.y;

		foreach (Spawner spawnerObj in spawnArray) {
			if (myYPos == spawnerObj.transform.position.y) {
				myLaneSpawner = spawnerObj;
				return;
			}
		}

			Debug.LogError ("Can't find spawner in lane");
	}
}
