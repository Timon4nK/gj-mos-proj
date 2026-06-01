using System;
using Godot;

public enum Direction
{
	North,
	West,
	South,
	East
}

public partial class FieldObject : Sprite2D
{
	protected int MOVE_DISTANCE = GameField.MOVE_DISTANCE;
	public int gridPosX { get; set; }
	public int gridPosY { get; set; }
	protected FieldObject() { } // Только для пресетов


	public FieldObject(int X, int Y)
	{
		gridPosX = X;
		gridPosY = Y;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
	}
	protected virtual void Score()
	{
		return;
	}

	private void CheckCollision(Direction direction)
	{
		if (gridPosX < 0 || gridPosX > 4 || gridPosY < 0 || gridPosY > 4)
		{
			Score();
			return;
		}

		GameField.Grid[gridPosX, gridPosY].MoveOnGrid(direction);
		GameField.Grid[gridPosX, gridPosY] = this;

	}
	public void MoveOnGrid(Direction direction)
	{
		GameField.Grid[gridPosX, gridPosY] = new FieldObject(gridPosX, gridPosY);

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

		//TODO: Протестировать отрисовку
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
	}	
}
