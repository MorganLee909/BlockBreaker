using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake() {
		if(instance != null) {
			Destroy(gameObject);
			print("Duplicate music player self-destruct");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	void Start () {		
	}
	
	void Update () {
	
	}
}
