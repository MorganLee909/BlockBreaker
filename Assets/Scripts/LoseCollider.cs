using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	public LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger) {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		print("Trigger");
		levelManager.LoadLevel("Lose");
		Brick.breakableCount = 0;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print("Collision");
	}
}
