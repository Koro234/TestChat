using Godot;
using System;

public class Global : Node
{
    public string UserName {get; set;} = "User";
    public string ServerName {get; set;} = "Server";
    public string Ip {get; set;} = "";
    public int Port {get; set;} = 0;
    public int Quantity {get; set;} = 0;
    
}
