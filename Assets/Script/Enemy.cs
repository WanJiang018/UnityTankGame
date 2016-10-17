using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int linercount, angilarcount;
	private bool targetfound = false, forward=true, turn=false;
	private RaycastHit hit;
	private float previousFire, nextFire;

	public GameObject TankEmitter, Bullet;

	//setting enemy attack
	public int HP;
	public ParticleSystem smoke;
	public GameObject Explosion;



	void Start () {
		previousFire = Time.time;
	}
	

	void Update () {
	   
		if (!targetfound) {
			if(linercount<200 && forward) //現在的狀態屬於直線直走的話則向前移動
			{
				transform.Translate(transform.forward*1.0f,Space.World);
				linercount++;

			}
		
		}

		if(linercount==200 && !turn)//已經走了一特定距離,轉換狀態為'迴轉'
		{

			turn=!turn;
			forward=!forward;

		}

		if(turn){     //迴轉狀態下,一次轉兩度

			transform.Rotate(new Vector3(0,1,0),2.0f);
			angilarcount++;


			if(angilarcount==90) //轉完180度後則回到直線行走狀態
			{
				angilarcount = 0;
				linercount = 0;
				turn=!turn;
				forward=!forward;

			}
		}

		//found player
		//向正前方射出一條射線

		if (Physics.Raycast (transform.position, transform.forward, out hit, 100.0f)) {

			Debug.Log ("found player");
		

			if(hit.collider.tag =="player")
			{    
				nextFire=Time.time;
				if(nextFire-previousFire>2.0f)
				{
					targetfound=true;
					GameObject newBullet = (GameObject)Instantiate(Bullet);

					newBullet.transform.position = TankEmitter.transform.position + TankEmitter.transform.right*10;
				
					newBullet.GetComponent<Rigidbody>().AddForce(TankEmitter.transform.right*10000);

					previousFire = Time.time;


				}

			}

			else targetfound=false;
		
		}
		else targetfound=false;

		}

	
	//attacked

	public void attacked()
	{
		HP--;
		if(HP==1)
		{
			smoke.Play ();
			
			
		}
		
		if(HP==0)
		{
			GameObject newExplosion = (GameObject)Instantiate (Explosion, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
			
		}

	}
}
