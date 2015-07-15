#MEMO of UNET
- ネットワークで同期させる変数、モノは、全てServer側で動かす
- ClientからServer側の関数を呼ぶときは`[Command]`Attributeをつける。
- 同期させる変数には`[sync]`Attributeを付け、ServerからClientに同期される。`[sync]`の変数がClient側で変化した時に呼ばれる関数も指定できる。`[sync(hook="SomeFunc")]`
- `if(NetworkServer.active)`Serverとして動作しているとき
- `if(NetworkClient.active)`



```csharp
var manager = GetComponent<NetworkManager>();
manager.StartServer(); //server
manager.StartClient(); //client
manager.StartHost(); //serverかつclient
manager.StopServer();
```
とかで、Serverを立てたり、Clientで接続したり。止めたり。

```csharp
manager.OnStartClient(NetworkClient client)
manager.OnClientConnect(NetworkConnection conn){}

```
とかの関数をoverrideして、処理を追加。デフォルトの処理はセットしてある。と、マニュアルには書いてある。ので、`base.OnStartClient()`とかで呼ぶのが良さそう。

