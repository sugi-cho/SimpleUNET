using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Linq;

public class ReconnectableNetworkManager : NetworkManager
{
    [SerializeField]
    bool isHost;

    void Start()
    {
        if (Application.platform != RuntimePlatform.OSXEditor || Application.platform != RuntimePlatform.OSXEditor)
        {
            var args = System.Environment.GetCommandLineArgs();
            isHost = args.Contains("-Host");
        }
        Connect();
    }
    void Connect()
    {
        if (isHost)
            StartHost();
        else
            StartClient();
	}
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        Invoke("Connect", 1f);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        Invoke("Connect", 1f);
    }

}
