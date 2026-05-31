using System;
using Godot;

public partial class FieldObject : Sprite2D
{
	protected int MOVE_DISTANCE = GameField.MOVE_DISTANCE;
	public int gridPosX { get; set; }
	public int gridPosY { get; set; }
	public FieldObject() { }


    public FieldObject(int X, int Y)
	{
		gridPosX = X;
		gridPosY = Y;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
	}
	private void Score()
	{

	}

	private void CheckCollision(Direction direction)
	{
		if (gridPosX < 0 || gridPosX > 4 || gridPosY < 0 || gridPosY > 4)
		{
			Score();
			return;
		}

		GameField.Instance.Grid[gridPosX, gridPosY].MoveOnGrid(direction);

	}
	public void MoveOnGrid(Direction direction)
	{
		switch (direction)
		{
			case Direction.North:
				gridPosY--;
				break;
			case Direction.West:
				gridPosX--;
				break;
			case Direction.South:
				gridPosY++;
				break;
			case Direction.East:
				gridPosX++;
				break;
		}
		CheckCollision(direction);

		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
	}
	
}
