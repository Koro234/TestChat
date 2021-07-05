using Godot;
using System;

public class ServerMenu : Control
{
    private Button Start;
    private Button Back;
    private LineEdit Port;
    private LineEdit Quantity;
    private LineEdit NameServer;
    public override void _Ready()
    {
        Start = GetNode<Button>("StartButton");
        Back = GetNode<Button>("BackButton");
        Port = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelPort/PortEdit");
        Quantity = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelQuantity/QuantityEdit");
        NameServer = GetNode<LineEdit>("HBoxContainer/LinesEdit/PanelName/NameEdit");
        Start.Connect("pressed", this, nameof(_on_Start_pressed));
        Back.Connect("pressed", this, nameof(_on_Back_pressed));
    }
    private void _on_Start_pressed()
    {
        var Global = (Global)GetNode("/root/Global");
        Global.Port = Port.Text.ToInt();
        Global.Quantity = Quantity.Text.ToInt();
        Global.ServerName = NameServer.Text;
        GetTree().ChangeScene("res://Server.tscn");
    }
    private void _on_Back_pressed()
    {
        GetTree().ChangeScene("res://MainMenu.tscn");
    }
}
