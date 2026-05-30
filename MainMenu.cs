using Godot;
using System;

public partial class MainMenu : Node2D
{
	public Button ButtonPlay;
	public AudioStreamPlayer ButtonSound;
	public AudioStreamPlayer Svidanie1;
	public override void _Ready()
	{
		Svidanie1 = GetNode<AudioStreamPlayer>("Svidanie1");
		ButtonSound = GetNode<AudioStreamPlayer>("ButtonSound");
		//Svidanie1.Play();
	}
	
	void _on_button_play_pressed()
	{ 
		ButtonSound.Play();
		Svidanie1.Stop();
		GetTree().ChangeSceneToFile("res://Maps/MainScreen.tscn");
	}
	void _on_button_exit_pressed()
	{
		ButtonSound.Play();
		GetTree().Quit();
	}
}