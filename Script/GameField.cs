using Godot;
using System;


public partial class GameField : Node
{
	private GameField() { }
	private static GameField _instance;
	public static GameField Instance => _instance ??= new GameField();

	public static int MOVE_DISTANCE = 100;
	public static FieldObject[,] Grid = new FieldObject[,]
		{
		{new FieldObject(0,0), new FieldObject(1,0), new FieldObject(2,0), new FieldObject(3,0), new FieldObject(4,0) },
		{new FieldObject(0,1), new FieldObject(1,1), new FieldObject(2,1), new FieldObject(3,1), new FieldObject(4,1) },
		{new FieldObject(0,2), new FieldObject(1,2), Player.Instance,      new FieldObject(3,2), new FieldObject(4,2) },
		{new FieldObject(0,3), new FieldObject(1,3), new FieldObject(2,3), new FieldObject(3,3), new FieldObject(4,3) },
		{new FieldObject(0,4), new FieldObject(1,4), new FieldObject(2,4), new FieldObject(3,4), new FieldObject(4,4) }
		};

	public static void _DEBUG_Print()
	{
		GD.Print("_DEBUG_Print:");

		for (int i = 0; i < 5; i++)
		{
			string _DEBUG_output = "";
			for (int j = 0; j < 5; j++)
			{
				_DEBUG_output += Grid[j, i].GetType().Name + " ";
			}
			GD.Print(_DEBUG_output);
		}
	}


	public static void GenerateNextLevel(bool hardMode)
	{
		Godot.Collections.Array<Node> children = Instance.GetChildren();

		foreach (Node child in children)
		{
			if (child.GetType().Name != "Player")
			{
				// ГРОМ И МОЛНИЯ, Я ПРИЗЫВАЮ ТЕБЯ, ГЦ!
				child.QueueFree();
			}
		}

		Grid = new FieldObject[,]
		{
		{new FieldObject(0,0), new FieldObject(1,0), new FieldObject(2,0), new FieldObject(3,0), new FieldObject(4,0) },
		{new FieldObject(0,1), new FieldObject(1,1), new FieldObject(2,1), new FieldObject(3,1), new FieldObject(4,1) },
		{new FieldObject(0,2), new FieldObject(1,2), new FieldObject(2,2), new FieldObject(3,2), new FieldObject(4,2) },
		{new FieldObject(0,3), new FieldObject(1,3), new FieldObject(2,3), new FieldObject(3,3), new FieldObject(4,3) },
		{new FieldObject(0,4), new FieldObject(1,4), new FieldObject(2,4), new FieldObject(3,4), new FieldObject(4,4) }
		};

		Grid[Player.Instance.gridPosY, Player.Instance.gridPosX] = Player.Instance;

		foreach (FieldObject item in Grid)
		{
            if (item.GetType().Name != "Player")
            {
                Instance.AddChild(item);
            }
		}
	}
}
