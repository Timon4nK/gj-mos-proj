using Godot;
using System;


public partial class GameField : Node
{
	private GameField() { }
	private static GameField _instance;
	public static GameField Instance => _instance ??= new GameField();

	public static int MOVE_DISTANCE = 100;
	public FieldObject[,] Grid = new FieldObject[,]
		{
		{new FieldObject(0,0), new FieldObject(1,0), new FieldObject(2,0), new FieldObject(3,0), new FieldObject(4,0) },
		{new FieldObject(0,1), new FieldObject(1,1), new FieldObject(2,1), new FieldObject(3,1), new FieldObject(4,1) },
		{new FieldObject(0,2), new FieldObject(1,2), new FieldObject(2,2), new FieldObject(3,2), new FieldObject(4,2) },
		{new FieldObject(0,3), new FieldObject(1,3), new FieldObject(2,3), new FieldObject(3,3), new FieldObject(4,3) },
		{new FieldObject(0,4), new FieldObject(1,4), new FieldObject(2,4), new FieldObject(3,4), new FieldObject(4,4) }
		};
}