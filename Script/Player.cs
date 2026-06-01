using Godot;
using System;

public partial class Player : FieldObject
{
	public Button ButtonNorth;
	public Button ButtonEast;
	public Button ButtonSouth;
	public Button ButtonWest;

	private static Player _instance;
	public static Player Instance => _instance ??= new Player();
	protected Player()
	{
		gridPosX = 2;
		gridPosY = 2;
	}
	public Player(int X, int Y)
	{
		gridPosX = X;
		gridPosY = Y;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
		Texture = GD.Load<Texture2D>("res://icon.svg");
	}

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
