using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

	private bool connected = false;
	private bool waiting = false;

	public void MyStartHost(){
		Debug.Log (Time.timeSinceLevelLoad + " : Starting Host. ");
		StartHost (); 
	}

	public override void OnStartHost(){
		Debug.Log (Time.timeSinceLevelLoad + " : Host created." );
	}

	public override void OnStartClient(NetworkClient myClient){
		Debug.Log (Time.timeSinceLevelLoad + " : Client start requested.");
		waiting = true;
	}

	void Update (){
		if (waiting && !connected) {
			InvokeRepeating ("Waiting", 1f, 1f);
		}
	}

	public override void OnClientConnect(NetworkConnection conn){
		connected = true;
		waiting = false;
		Debug.Log (Time.timeSinceLevelLoad + " : Client is connected at IP: " + conn.address);
	}

	void Waiting(){
		print (". ");
	}
}
