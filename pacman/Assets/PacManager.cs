using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PacManager : NetworkManager {

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
		NetworkServer.AddPlayerForConnection (conn, instantiatePacman (), playerControllerId);
	}

	GameObject instantiatePacman() {
		return (GameObject)Instantiate (base.playerPrefab, new Vector3 (14, 14), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
