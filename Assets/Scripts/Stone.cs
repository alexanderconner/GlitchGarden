using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator animator;


	void Start() {
		animator = GetComponent<Animator> ();
	}

	void Update() {

	}

	void OnTriggerStay2D(Collider2D collider)
	{
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		if (attacker) {
			animator.SetTrigger ("underAttack");
		}
	}
}
