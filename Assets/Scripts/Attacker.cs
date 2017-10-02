using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances.")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}
		

	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}

	//Called from animator at time of blow
	public void StrikeCurrentTarget(float damage)
	{
		if (currentTarget) {
			Debug.Log (name + "Doing " + damage + " Damage.");
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}

	}

	//Called and set by attacker type script
	public void Attack (GameObject obj) {
		currentTarget = obj;
	}
}
