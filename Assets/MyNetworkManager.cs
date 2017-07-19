using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {

	private bool connected = false;

	public void MyStartHost(){
		Debug.Log (Time.timeSinceLevelLoad + " : Starting Host. ");
		StartHost (); 
	}

	public override void OnStartHost(){
		Debug.Log (Time.timeSinceLevelLoad + " : Host created." );
	}

	public override void OnStartClient(NetworkClient myClient){
		Debug.Log (Time.timeSinceLevelLoad + " : Client start requested.");
	}

	void Update (){
		if (!connected) {
			InvokeRepeating ("Waiting", 1f, 1f);
		}
	}

	public override void OnClientConnect(NetworkConnection conn){
		connected = true;
		Debug.Log (Time.timeSinceLevelLoad + " : Client is connected at IP: " + conn.address);
	}

	void Waiting(){
		print (". ");
	}
}
