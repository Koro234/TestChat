using Godot;
using System;

public class MainMenu : Control
{
	[Export]
	public PackedScene ClientScene;
	[Export]
	public PackedScene ServerScene;
	public override void _Ready()
	{
		GetNode("ServerButton").Connect("pressed", this, nameof(_on_ServerButton_pressed));
		GetNode("ClientButton").Connect("pressed", this, nameof(_on_ClientButton_pressed));
	}
	public void _on_ClientButton_pressed()
	{
		GetTree().ChangeSceneTo(ClientScene);
	}

	public void _on_ServerButton_pressed()
	{
		GetTree().ChangeSceneTo(ServerScene);
	}
}
