using Godot;
using System;

public partial class MainScreen : Node2D
{
	public int Score = 0;
	public AudioStreamPlayer Svidanie3; 
	
	//Для теста
	public Button ButtonWin;
	public Button ButtonLose;
	
	
	public override void _Ready()
	{
		Svidanie3 = GetNode<AudioStreamPlayer>("Svidanie3");
		//Svidanie3.Play(0);
	}
	
	void _on_button_win_pressed()
	{
		GetTree().ChangeSceneToFile("res://Maps/WinScreen.tscn"); 
	}
	void _on_button_lose_pressed()
	{
		GetTree().ChangeSceneToFile("res://Maps/LoseScreen.tscn");
	}
	void _on_button_debug_1_pressed()
	{

	}
	void _on_button_debug_2_pressed()
	{

	}
}
