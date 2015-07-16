using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SimplePlayer : NetworkBehaviour
{
    [SerializeField]
    GameObject tama;
    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Input.mousePosition;
            pos.z = 10f;
            pos = Camera.main.ScreenToWorldPoint(pos);
            CmdSpawnTama(pos);
        }
    }

    [Command]
    void CmdSpawnTama(Vector3 pos)
    {
        var go = (GameObject)Instantiate(tama, pos, Quaternion.identity);
        NetworkServer.Spawn(go);
    }
}
