using Godot;
using System;

public class NetworkServer : Node, ISender
{
    [Export]
    private PackedScene ChatScene;
    private Chat Chat;
    private int Port;
    private int PlayersQuantity;
    private NetworkedMultiplayerENet Peer;
    public override void _Ready()
    {
        var Global = (Global)GetNode("/root/Global");
        Port = Global.Port;
        PlayersQuantity = Global.Quantity;
        Peer = new NetworkedMultiplayerENet();
        Peer.CreateServer(Port, PlayersQuantity);
        GetTree().NetworkPeer = Peer;
        AddChild(ChatScene.Instance());
        Chat = (Chat)GetNode("Chat");
        Chat.SetName();
    }
    public void MessengeSender(string UserName, string Messenge)
    {
        Chat.AddMessenge(0, UserName, Messenge);
        RpcId(0, "MessengeTaker", 0, UserName, Messenge);
    }
    [Remote]
    public void MessengeTransmitter(int Chanal, string UserName, string Messenge)
    {
        Chat.AddMessenge(Chanal, UserName, Messenge);
        RpcId(0, "MessengeTaker", Chanal, UserName, Messenge);
    }
}
