using Godot;
using System;

public partial class LoseScreen : Node2D
{
	public Button ButtonMenu;	
	public Button ButtonPlay;
	public AudioStreamPlayer FailSound; 	

	public override void _Ready()
	{
		FailSound = GetNode<AudioStreamPlayer>("FailSound");
		FailSound.Play(0);
	}	

	
	void _on_button_menu_pressed()
	{
		GetTree().ChangeSceneToFile("res://Maps/MainMenu.tscn"); 
	}
	void _on_button_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://Maps/MainScreen.tscn"); 
	}	
}
