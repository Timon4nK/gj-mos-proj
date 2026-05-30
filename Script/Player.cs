using Godot;
using System;

public enum Direction
{
	North,
	West,
	South,
	East
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
		
	void directionalButtonHandler(Direction direction)
	{
		switch (direction)
		{
			case Direction.North:
				Position =
				new Vector2(Position.X, Position.Y - MOVE_DISTANCE);
				break;
			case Direction.West:
				Position =
				new Vector2(Position.X - MOVE_DISTANCE, Position.Y);
				break;
			case Direction.South:
				Position =
				new Vector2(Position.X, Position.Y + MOVE_DISTANCE);
				break;
			case Direction.East:
				Position =
				new Vector2(Position.X + MOVE_DISTANCE, Position.Y);
				break;
		}
	}

	void _on_button_north_pressed() { directionalButtonHandler(Direction.North); }
	void _on_button_east_pressed() { directionalButtonHandler(Direction.East); }
	void _on_button_south_pressed() { directionalButtonHandler(Direction.South); }
	void _on_button_west_pressed() { directionalButtonHandler(Direction.West); }
}