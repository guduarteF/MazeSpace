
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : MonoBehaviour
{
    public GameObject Player2Prefab,Player1Prefab,spawnP1,spawnP2;
    NetworkClient myClient;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClientConnect()
    {
        ClientScene.RegisterPrefab(Player1Prefab);
        ClientScene.RegisterPrefab(Player2Prefab);
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnClientConnect);
        myClient.Connect("127.0.0.1", 4444);
    }

    void OnClientConnect(NetworkMessage msg)
    {
        Debug.Log("Connect to server: " + msg.conn);
    }

    public void ServerListen()
    {
        NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnect);
        NetworkServer.RegisterHandler(MsgType.Ready, OnClientReady);

        if (NetworkServer.Listen(4444))
        {
            Debug.Log("Server started listening on port 4444");
        }
    }
        void OnClientReady(NetworkMessage msg)
        {
            Debug.Log("Client is ready to start :" + msg.conn);
            NetworkServer.SetClientReady(msg.conn);
            SpawnPlayer();
        }

        void SpawnPlayer()
        {
        var player = Instantiate(Player1Prefab, spawnP1.transform.position, Quaternion.identity);
        NetworkServer.Spawn(player);
        }

    void OnServerConnect(NetworkMessage msg)
    {
        Debug.Log("New client coneected: " + msg.conn);
    }
}

