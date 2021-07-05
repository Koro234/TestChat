using Godot;
using System;

public class Chat : Control
{
    private Label UserName;
    private RichTextLabel ChatLog;
    private Button Send;
    private LineEdit TextLine;
    private string[][] Chanals = new string[2][];
    private ISender Network;
    public override void _Ready()
    {
        UserName = (Label)GetNode("VBoxContainer/HBoxContainer/Name");
        Send = (Button)GetNode("VBoxContainer/HBoxContainer/SendButton");
        TextLine = (LineEdit)GetNode("VBoxContainer/HBoxContainer/Messenge");
        ChatLog = (RichTextLabel)GetNode("VBoxContainer/RichTextLabel");
        Chanals[0] = new string[]{"Server", "#b80000"};
        Chanals[1] = new string[]{"Other", "#a13aff"};
        Network = (ISender)GetNode("/root/Network");
        Send.Connect("pressed", this, nameof(_on_Send_pressed));
    }
    public void AddMessenge(int ChatChanal, string username, string text)
    {
        ChatLog.BbcodeText += "\n";
        ChatLog.BbcodeText += "[color=" + Chanals[ChatChanal][1] + "]";;
        ChatLog.BbcodeText += "[" + Chanals[ChatChanal][0] + "]";
        ChatLog.BbcodeText += "[" + username + "]";
        ChatLog.BbcodeText += ": " + text;
        ChatLog.BbcodeText += "[/color]";
    }
    public void _on_Send_pressed()
    {
        if (TextLine.Text == "")
        {
            return;
        }
        Network.MessengeSender(UserName.Text, TextLine.Text);
        TextLine.Text = "";
    }
    public void SetName()
    {
        var Global = (Global)GetNode("/root/Global");
        if (GetTree().IsNetworkServer())
        {
            UserName.Text = "[" + Global.ServerName + "]";
        }
        else
        {
            UserName.Text = "[" + Global.UserName + "]";
        }
    }
}
