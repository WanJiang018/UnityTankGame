using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	int anglenow;
	int top_anglenow;

	public GameObject Tankbody;
	public GameObject TankTop;
	public GameObject TankEmitter;
	public GameObject Bullet;


	//attacked

	public GameObject Explosion;
	public Camera tankCamera;
	public Camera mainCamera;
	public int HP;
	public GUITexture life;

	public ReloadBullet reloadbullet;

	public Camera tCamera;

	void Start () {

		//setting for initialization
		tCamera.transform.rotation = TankTop.transform.rotation;
		tCamera.transform.Rotate (new Vector3 (1, 0, 0), 10);
		tCamera.transform.position = TankTop.transform.position - TankTop.transform.forward*10.0f +TankTop.transform.up*10.0f;


		UpdateLifeTexture (HP);
	
	}
	

	void Update () {


	   if (Input.GetKey (KeyCode.W)) 
		{
			Tankbody.transform.Translate(Tankbody.transform.forward*Time.deltaTime*10,Space.World);

	    }

		if (Input.GetKey (KeyCode.S)) 
		{
			Tankbody.transform.Translate(Tankbody.transform.forward*Time.deltaTime*-10,Space.World);
			
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			Tankbody.transform.Rotate(new Vector3(0,-10,0),1);
			
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			Tankbody.transform.Rotate(new Vector3(0,10,0),1);
			
		}

		//Bullet
		if (Input.GetKeyDown (KeyCode.Space)) 
		{   
			if(reloadbullet.IsReady())
			{

			
			GameObject newBullet=(GameObject)Instantiate(Bullet);
			newBullet.transform.position = TankEmitter.transform.position + TankEmitter.transform.right*10;
			newBullet.GetComponent<Rigidbody>().AddForce(TankEmitter.transform.right*10000);
			reloadbullet.StartToloading();
			}
		}


  }


	public void attacked()
	{
		HP--;
		if (HP == 0) {
		
			GameObject newExplosion = (GameObject)Instantiate (Explosion, transform.position, Quaternion.identity);

			Destroy(this.gameObject);

			tankCamera.enabled=false;
			mainCamera.enabled=true;
		
		}
		
		UpdateLifeTexture (HP);
	}


	void UpdateLifeTexture(int HP)
	{
		switch (HP) {
		case 0:
			life.color = new Color(0,0,0,0);
			break;
		case 1:
			life.color = new Color(1,0,0);
			break;
		case 2:
			life.color = new Color(1,0.5f,0);
			break;
		case 3:
			life.color = new Color(0,1,0);
			break;
		default:
			life.color = new Color(0,0,0,0);
			break;
		
		}

	}
}