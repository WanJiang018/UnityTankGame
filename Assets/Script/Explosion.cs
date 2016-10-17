using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public AudioClip ExplosionSound;

	public void PlaySound () {

		this.GetComponent<AudioSource> ().PlayOneShot (ExplosionSound);
	
	}
	

}
