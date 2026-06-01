using System;
using Godot;

public partial class Orb : FieldObject 
{
	protected Orb() { } // Debug only
	public string OrbType;
	public Orb(int X, int Y, string orbType="green")
	{
		gridPosX = X;
		gridPosY = Y;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
		OrbType = orbType;
		// TODO: Текстуры
	}

    protected override void Score()
    {
		switch (OrbType)
		{
			case "green":
				MainScreen.Score += 1;
				GameField.GenerateNextLevel(false);
				break;
            case "red":
                MainScreen.Score -= 1;
                break;
            case "black":
                MainScreen.Score -= 2;
                break;
            case "pink":
                MainScreen.Score += 1;
                GameField.GenerateNextLevel(true);
                break;
        }
    }
}
