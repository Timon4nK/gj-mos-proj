using Godot;
using System;

public partial class SoundPanel : Node2D
{
	public AudioStreamPlayer AmbientMusic;
	private Button ButtonMusicOff;
	private Button ButtonSoundsOff;
	public bool isMusicPlaying = true;
	public bool isSoundsPlaying = true;

	public override void _Ready()
	{
		ButtonMusicOff = GetNode<Button>("ButtonMusicOff");
		ButtonSoundsOff = GetNode<Button>("ButtonSoundsOff");
		//AmbientMusic = GetNode<AudioStreamPlayer>("");

	}

	void _on_button_music_off_pressed()
	{
		if (isMusicPlaying) 
		{
			isMusicPlaying = false;
			ButtonMusicOff.Text="Нажмите 1 чтобы включить музыку";
		}
		else
		{
			isMusicPlaying = true;
			ButtonMusicOff.Text="Нажмите 1 чтобы выключить музыку";
		}
	}
	
	void _on_button_sounds_off_pressed()
	{
		if (isMusicPlaying) 
		{
			isSoundsPlaying = false;
			ButtonMusicOff.Text="Нажмите 2 чтобы включить звуки";
		}
		else
		{
			isSoundsPlaying = true;
			ButtonMusicOff.Text="Нажмите 2 чтобы выключить звуки";
		}
	}
}
