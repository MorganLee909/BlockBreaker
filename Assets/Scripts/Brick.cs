using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	public AudioClip crack;
	public AudioClip boing;
	public GameObject smoke;

	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
			AudioSource.PlayClipAtPoint(boing, transform.position, 0.8f);
		} else {
			LoadSprites();
			AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
		}
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}

	void Win() {
		levelManager.LoadNextLevel ();
	}
}
