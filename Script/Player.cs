using Godot;
using System;

public partial class Player : FieldObject
{
	public Button ButtonNorth;
	public Button ButtonEast;
	public Button ButtonSouth;
	public Button ButtonWest;

	public override void _Ready()
	{
		ButtonNorth  = GetNode<Button>("ButtonNorth");
		ButtonEast   = GetNode<Button>("ButtonEast");
		ButtonSouth  = GetNode<Button>("ButtonSouth");
		ButtonWest	 = GetNode<Button>("ButtonWest");
	}
		
	void directionalButtonHandler(Direction direction)
	{
		MoveOnGrid(direction);
		// TODO: звуки кнопок
	}

	void _on_button_north_pressed() { directionalButtonHandler(Direction.North); }
	void _on_button_east_pressed() { directionalButtonHandler(Direction.East); }
	void _on_button_south_pressed() { directionalButtonHandler(Direction.South); }
	void _on_button_west_pressed() { directionalButtonHandler(Direction.West); }
}
