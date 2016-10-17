using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public GameObject Explosion;
	public Material material;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Destroy (this.gameObject);
		GameObject newExplosion =
			(GameObject)Instantiate (Explosion, transform.position, Quaternion.identity);
		newExplosion.GetComponent<Explosion> ().PlaySound ();

		switch (other.tag) {
		case"barrel":
			other.GetComponent<Renderer>().material = material;
			break;

		case"Enemy":
				other.GetComponent<Enemy>().attacked();
			break;
		
		case"player":
				other.GetComponent<Player>().attacked();
			break;
		default:
			break;


		
		}

	}



}
