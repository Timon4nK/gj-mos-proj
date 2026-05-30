using Godot;
using System;

public partial class SoundPanel : Node2D
{
	public Button ButtonMusicOff;
	public Button ButtonSoundsOff;
	public bool isMusicPlaying = true;
	public bool isSoundsPlaying = true;

	public override void _Ready()
		{
			ButtonMusicOff = GetNode<Button>("ButtonMusicOff");
		}	

	void _on_button_music_off_pressed()
	{
		if (isMusicPlaying==true) 
		{	
			GD.Print("qweqweqwe");
			isMusicPlaying = false;
			ButtonMusicOff.Text="Нажмите 1 чтобы включить музыку";
		}
		else
		{
			isMusicPlaying = true;
			ButtonMusicOff.Text="Нажмите 1 чтобы выключить музыку";		
		}
	}

	
}
