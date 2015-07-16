#MEMO of UNET
##概要
Unityで、複数PC、複数画面間をオブジェクトを同期させて表示させる作品を次に作りそうなので、Unity5.1から、新しくなった、UnityのNetworking機能、UNETについて調べて、実装してみました。  
メモとかです。そんなに、まとまっていません。
<iframe width="420" height="315" src="https://www.youtube.com/embed/--fKAwlUUAM" frameborder="0" allowfullscreen></iframe>
##ポイント
- `using UnityEngine.Networking;`
- ネットワークで同期させる変数、モノは、全てServer側で動かす
- ClientからServer側の関数を呼ぶときは`[Command]`Attributeをつける。
- 同期させる変数には`[sync]`Attributeを付け、ServerからClientに同期される。`[sync]`の変数がClient側で変化した時に呼ばれる関数も指定できる。`[sync(hook="SomeFunc")]`
- `if(NetworkServer.active)`Serverとして動作しているとき
- `if(NetworkClient.active)`


##Serverを立てたりClientを接続したり
```csharp
var manager = GetComponent<NetworkManager>();
manager.StartServer(); //server
manager.StartClient(); //client
manager.StartHost(); //serverかつclient
manager.StopServer();
```
とかで、Serverを立てたり、Clientで接続したり。止めたり。

##NetworkManager
[NetworkManager](http://docs.unity3d.com/ja/current/ScriptReference/Networking.NetworkManager.html)のクラスを継承して、Networkの独自処理をするComponentを作っていく。  
NetworkManagerをそのまま使っても、重要な部分の処理は既に書かれているので、かなり、ラクできる。

```csharp
using UnityEngine;
using UnityEngine.Networking;

public class MyNetManager:NetworkManager{
	public override void OnStartClient(NetworkClient client){
		base.OnStartClient(client);
		//処理
	}
	public override void OnClientConnect(NetworkConnection conn){
		//.....
	}

```

##Link
- [ExampleScenes](http://forum.unity3d.com/threads/unet-sample-projects.331978/) Unity のForumにあった。
- [NetworkManagerHUD.cs](http://forum.unity3d.com/threads/networkmanagerhud-code-network-control-and-matchmaking-example.326604/) 参考になる。（NetworkManagerHUDは、NetworkingをサクッとデバッグするためのComponentだと思ってる。）
- [SimpleUNET](https://github.com/sugi-cho/SimpleUNET) ぼくが調べながら作ったやつ。記述量少なめで、ネットワーキングのテストをするコード


