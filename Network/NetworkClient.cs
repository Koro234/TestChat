using Godot;
using System;

public class NetworkClient : Node, ISender
{
    [Export]
    private PackedScene ChatScene;
    private Chat Chat;
    private int Port;
    private string Ip;
    private NetworkedMultiplayerENet Peer;
    public override void _Ready()
    {
        var Global = (Global)GetNode("/root/Global");
        Port = Global.Port;
        Ip = Global.Ip;
        Peer = new NetworkedMultiplayerENet();
        Peer.CreateClient(Ip, Port);
        GetTree().NetworkPeer = Peer;
        AddChild(ChatScene.Instance());
        Chat = (Chat)GetNode("Chat");
        Chat.SetName();
    }
    public void MessengeSender(string UserName, string Messenge)
    {
        RpcId(1, "MessengeTransmitter", 1, UserName, Messenge);
    }
    [Remote]
    public void MessengeTaker(int Chanal, string UserName, string Messenge)
    {
        Chat.AddMessenge(Chanal, UserName, Messenge);
    }
}
