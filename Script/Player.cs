using Godot;
using System;


public enum MDirection
{
	North,
	West,
	South,
	East,
	
}

public partial class Player : Node2D
{
	public Button ButtonNorth;
	public Button ButtonEast;
	public Button ButtonSouth;
	public Button ButtonWest;
	public const int MOVE_DISTANCE = 100;	
	
	public override void _Ready()
		{
		ButtonNorth  = GetNode<Button>("ButtonNorth");
		ButtonEast   = GetNode<Button>("ButtonEast");
		ButtonSouth  = GetNode<Button>("ButtonSouth");
		ButtonWest	 = GetNode<Button>("ButtonWest");
		}
		
	void directionalButtonHandler(MDirection mdirection)
	{
		switch (mdirection)
		{
			case MDirection.North:	
				Position = Position + Vector2.Up*MOVE_DISTANCE;
				ButtonNorth.Text="meow";
				break;
			case MDirection.West:
				Position =
				new Vector2(Position.X - MOVE_DISTANCE, Position.Y);
				break;
			case MDirection.South:
				Position =
				new Vector2(Position.X, Position.Y + MOVE_DISTANCE);
				break;
			case MDirection.East:
				Position =
				new Vector2(Position.X + MOVE_DISTANCE, Position.Y);
				break;}}

	void _on_button_north_pressed() { directionalButtonHandler(MDirection.North); }
	void _on_button_east_pressed() { directionalButtonHandler(MDirection.East); }
	void _on_button_south_pressed() { directionalButtonHandler(MDirection.South); }
	void _on_button_west_pressed() { directionalButtonHandler(MDirection.West); }
	
}
