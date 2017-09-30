using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker> ();
	}
		
	void OnTriggerEnter2D (Collider2D collider) {

		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<Defenders> ()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			Debug.Log ("Fox collided with Stone, jumping:" + collider);
			anim.SetTrigger ("jumpTrigger");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}

	}
}
