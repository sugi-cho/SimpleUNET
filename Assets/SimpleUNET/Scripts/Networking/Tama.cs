using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Tama : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isServer)
            Invoke("DestroyFromNetwork", 20f);
    }

    void DestroyFromNetwork()
    {
        NetworkServer.Destroy(gameObject);
    }
}
