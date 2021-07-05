using Godot;
using System;

public class ClientMenu : Control
{
    private Button Start;
    private Button Back;
    private LineEdit Port;
    private LineEdit Ip;
    private LineEdit UserName;
    public override void _Ready()
    {
        Start = GetNode<Button>("StartButton");
        Back = GetNode<Button>("BackButton");
        Port = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelPort/PortEdit");
        Ip = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelIp/IpEdit");
        UserName = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelName/NameEdit");
        Start.Connect("pressed", this, nameof(_on_Start_pressed));
        Back.Connect("pressed", this, nameof(_on_Back_pressed));
    }
    private void _on_Start_pressed()
    {
        var Global = (Global)GetNode("/root/Global");
        Global.Port = Port.Text.ToInt();
        Global.Ip = Ip.Text;
        Global.UserName = UserName.Text;
        GetTree().ChangeScene("res://Client.tscn");
    }
    private void _on_Back_pressed()
    {
        GetTree().ChangeScene("res://Menu/MainMenu.tscn");
    }
}
