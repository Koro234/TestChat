using Godot;
using System;

public class MainMenu : Control
{
	[Export]
	public PackedScene ClientScene;
	[Export]
	public PackedScene ServerScene;
	public void _on_ClientButton_pressed()
	{
		GetTree().ChangeSceneTo(ClientScene);
	}

	public void _on_ServerButton_pressed()
	{
		GetTree().ChangeSceneTo(ServerScene);
	}
}
