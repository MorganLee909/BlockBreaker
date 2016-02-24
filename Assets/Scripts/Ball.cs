using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if(Input.GetMouseButtonDown (0)) {
				print("Mouse Clicked, launching ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if(hasStarted) {
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
