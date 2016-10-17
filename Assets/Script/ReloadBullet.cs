using UnityEngine;
using System.Collections;

public class ReloadBullet : MonoBehaviour {
	public float timePrepare;

	float timeNow;
	float timeStart;
    

	enum loadState {loading , Idle};

	loadState currentState = loadState.Idle; 

	void Start () {
		GetComponent<GUIText> ().enabled = false;
	}
	

	void Update () {
	   if (currentState == loadState.loading) {
		
			timeNow = Time.time;

			if(timeNow-timeStart < timePrepare)
			{

				GetComponent<GUIText>().text = string.Format("{0:0}",timePrepare-(timeNow-timeStart));

			}

			else{

				currentState=loadState.Idle;
			}
		
		}

	}

	public void StartToloading()
	{

		currentState = loadState.loading;
		GetComponent<GUIText> ().enabled = true;
		timeStart = Time.time;

	}

	public bool IsReady()
	{

		return currentState == loadState.Idle;

	}
}
