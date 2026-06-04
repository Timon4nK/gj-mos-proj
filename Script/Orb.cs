using System;
using Godot;

public partial class Orb : FieldObject 
{
	protected Orb() { } // Debug only
	public string OrbType;
	public string InText;
	public string OutText;
	public Orb(int X, int Y, string orbType="green", string inText="test", string outText="Test")
	{
		gridPosX = X;
		gridPosY = Y;
		Position = new Vector2(gridPosX * MOVE_DISTANCE, gridPosY * MOVE_DISTANCE);
		OrbType = orbType;
        InText = inText;
        OutText = outText;
        // TODO: Текстуры
        Texture = GD.Load<Texture2D>("res://Sprites/Sphere_good.png");
    }
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://Sprites/Sphere_good.png");
    }

    protected override void Score()
    {
        GD.Print($"{OrbType} scored");
		/*switch (OrbType)
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
        }*/
    }
}
