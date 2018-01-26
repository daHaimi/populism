using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	const float randomChange = 0.5f;
	const float lerpValue = .6f;

	private Animator animator;
	private Transform t;
	private float targetTime = 1.0f;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		t = this.GetComponent<Transform> ();
		//GetComponent<Renderer> ().material.shader = Shader.Find ("HSVDefault");
	}

	// Update is called once per frame
	void Update()
	{
		targetTime -= Time.deltaTime;
		if (targetTime <= 0.0f) {
			if (Random.value <= randomChange) {
				var newDir = Mathf.FloorToInt (Random.value * 4.0f);
				animator.SetInteger("Direction", newDir);
			}
			targetTime = 1.0f;
		}

		var posOld = t.position;
		switch (animator.GetInteger("Direction")) {
		case 0:
			posOld.y -= lerpValue * Time.deltaTime;
			break;
		case 1:
			posOld.x -= lerpValue * Time.deltaTime;
			break;
		case 2:
			posOld.y += lerpValue * Time.deltaTime;
			break;
		default:
			posOld.x += lerpValue * Time.deltaTime;
			break;
		}
		t.position = posOld;
	}
}
