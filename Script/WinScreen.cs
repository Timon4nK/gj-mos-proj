using Godot;
using System;

public partial class WinScreen : Node2D
{
	public Button ButtonMenu;
	public AudioStreamPlayer WinSound; 



	public override void _Ready()
	{
		WinSound = GetNode<AudioStreamPlayer>("WinSound");
		WinSound.Play(0);
	}	
	
	
	void _on_button_menu_pressed()
	{
		GetTree().ChangeSceneToFile("res://Maps/MainMenu.tscn"); 
	}
}
