using Godot;
using System;

public partial class Player : FieldObject
{
	public Button ButtonNorth;
	public Button ButtonEast;
	public Button ButtonSouth;
	public Button ButtonWest;

	public static int playerPosX { get; set; }
	public static int playerPosY { get; set; }
	
	public override void _Ready()
	{
		ButtonNorth  = GetNode<Button>("ButtonNorth");
		ButtonEast   = GetNode<Button>("ButtonEast");
		ButtonSouth  = GetNode<Button>("ButtonSouth");
		ButtonWest	 = GetNode<Button>("ButtonWest");

		gridPosX = 2; gridPosY = 2;
		playerPosX = 2; playerPosY = 2;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
	}
		
	void directionalButtonHandler(Direction direction)
	{
		MoveOnGrid(direction);
		// TODO: звуки кнопок
		if(gridPosX > 0) ButtonWest.Visible = true;
		else ButtonWest.Visible = false;
		if (gridPosY > 0) ButtonNorth.Visible = true;
		else ButtonNorth.Visible = false;
		if (gridPosX < 4) ButtonEast.Visible = true;
		else ButtonEast.Visible = false;
		if (gridPosY < 4) ButtonSouth.Visible = true;
		else ButtonSouth.Visible = false;
	}

	void _on_button_north_pressed() { directionalButtonHandler(Direction.North); }
	void _on_button_east_pressed() { directionalButtonHandler(Direction.East); }
	void _on_button_south_pressed() { directionalButtonHandler(Direction.South); }
	void _on_button_west_pressed() { directionalButtonHandler(Direction.West); }
}
