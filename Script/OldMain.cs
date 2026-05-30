using System;
using System.Collections.Generic;
using Godot;

// Препроцессор

/*public enum SelectMode
{
	None,
	Move,
	Trap
}*/

/*public enum Direction
{
	North,
	NorthWest,
	West,
	SouthWest,
	South,
	SouthEast,
	East,
	NorthEast
}*/

/*public partial class OldMain : Node2D
{
	public const int BOARD_SIZE = 800;
	public const int MOVE_DISTANCE = BOARD_SIZE / 8;
	public SelectMode selectedMode = SelectMode.Move;
	public int jesterX = 3, jesterY = 3;
	public bool hasMoved = false, hasPlaced = false;
	public int turnNumber = 0;
	public int spawnCircle = 0;

	public char[,] boardObjectsMatrix = new char[,] // None Jester Pawn Bishop Rook Queen King
		{
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'J', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' },
		{ 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' }
		};

	Sprite2D protagonist, Board;

	Button ButtonNorth;
	Button ButtonNorthEast;
	Button ButtonEast;
	Button ButtonSouthEast;
	Button ButtonSouth;
	Button ButtonSouthWest;
	Button ButtonWest;
	Button ButtonNorthWest;
	Button ButtonTurn;

	RichTextLabel MovedLabel, PlacedLabel;

	List<Enemy> Enemies;

	Texture2D PawnTexture;

	void spawnEnemy(int X = -1, int Y = -1, char Type = 'P')
	{
		if(X == -1 || Y == -1)
		{	
			if(spawnCircle <= 7)
			{
				X = spawnCircle; Y = 0;
			}
			else if (spawnCircle <= 14)
			{
				X = 7; Y = spawnCircle - 7;
			}
			else if (spawnCircle <= 21)
			{
				X = 21 - spawnCircle; Y = 7;
			}
			else
			{
				X = 0; Y = 28 - spawnCircle;
			}
			spawnCircle += 5;
			spawnCircle %= 28;
		}

		boardObjectsMatrix[X, Y] = Type;        
		Enemies.Add(new Enemy(X, Y, Type));
		Enemies[^1].Texture = PawnTexture;
		Enemies[^1].Position = new Vector2(X * 100 - 350, Y * 100 - 350);
		Enemies[^1].Visible = true;

		Board.AddChild(Enemies[^1]);
	}

	void endTurn()
	{
		spawnEnemy();
		spawnEnemy();
		turnNumber++;
		hasMoved = false;
		hasPlaced = false;

		// Ход противников
	}

	void directionalButtonHandler(Direction direction)
	{
		if (selectedMode == SelectMode.Move)
		{
			boardObjectsMatrix[jesterX, jesterY] = 'N';

			switch (direction)
			{
				case Direction.North:	
					protagonist.Position =
					new Vector2(protagonist.Position.X, protagonist.Position.Y - MOVE_DISTANCE);
					jesterY--;
					break;
				case Direction.NorthWest:
					protagonist.Position =
					new Vector2(protagonist.Position.X - MOVE_DISTANCE, protagonist.Position.Y - MOVE_DISTANCE);
					jesterX--;
					jesterY--;
					break;
				case Direction.West:
					protagonist.Position =
					new Vector2(protagonist.Position.X - MOVE_DISTANCE, protagonist.Position.Y);
					jesterX--;
					break;
				case Direction.SouthWest:
					protagonist.Position =
					new Vector2(protagonist.Position.X - MOVE_DISTANCE, protagonist.Position.Y + MOVE_DISTANCE);
					jesterX--;
					jesterY++;
					break;
				case Direction.South:
					protagonist.Position =
					new Vector2(protagonist.Position.X, protagonist.Position.Y + MOVE_DISTANCE);
					jesterY++;
					break;
				case Direction.SouthEast:
					protagonist.Position =
					new Vector2(protagonist.Position.X + MOVE_DISTANCE, protagonist.Position.Y + MOVE_DISTANCE);
					jesterX++;
					jesterY++;
					break;
				case Direction.East:
					protagonist.Position =
					new Vector2(protagonist.Position.X + MOVE_DISTANCE, protagonist.Position.Y);
					jesterX++;
					break;
				case Direction.NorthEast:
					protagonist.Position =
					new Vector2(protagonist.Position.X + MOVE_DISTANCE, protagonist.Position.Y - MOVE_DISTANCE);
					jesterX++;
					jesterY--;
					break;
			}

			if (jesterX > 0 && jesterY > 0) ButtonNorthWest.Visible = true;
			else ButtonNorthWest.Visible = false;
			if (jesterX > 0) ButtonWest.Visible = true;
			else ButtonWest.Visible = false;
			if (jesterY > 0) ButtonNorth.Visible = true;
			else ButtonNorth.Visible = false;
			if (jesterX < 7 && jesterY < 7) ButtonSouthEast.Visible = true;
			else ButtonSouthEast.Visible = false;
			if (jesterX < 7) ButtonEast.Visible = true;
			else ButtonEast.Visible = false;
			if (jesterY < 7) ButtonSouth.Visible = true;
			else ButtonSouth.Visible = false;
			if (jesterX < 7 && jesterY > 0) ButtonNorthEast.Visible = true;
			else ButtonNorthEast.Visible = false;
			if (jesterX > 0 && jesterY < 7) ButtonSouthWest.Visible = true;
			else ButtonSouthWest.Visible = false;

			if (boardObjectsMatrix[jesterX, jesterY] != 'N')
			{
				// Обработать ловушки
			}

			boardObjectsMatrix[jesterX, jesterY] = 'J';
			hasMoved = true;
			//selectedMode = SelectMode.None;
		}

		else if (selectedMode == SelectMode.Trap)
		{
			// Создать ловушку:
			//boardObjectsMatrix[] = ' '

			// Кулдаун

			hasPlaced = true;
			//selectedMode = SelectMode.None;
		}

		// Проверка конца хода
		if (hasMoved && hasPlaced) endTurn();
	}

	void _on_button_north_pressed() { directionalButtonHandler(Direction.North); }
	void _on_button_north_east_pressed() { directionalButtonHandler(Direction.NorthEast); }
	void _on_button_east_pressed() { directionalButtonHandler(Direction.East); }
	void _on_button_south_east_pressed() { directionalButtonHandler(Direction.SouthEast); }
	void _on_button_south_pressed() { directionalButtonHandler(Direction.South); }
	void _on_button_south_west_pressed() { directionalButtonHandler(Direction.SouthWest); }
	void _on_button_west_pressed() { directionalButtonHandler(Direction.West); }
	void _on_button_north_west_pressed() { directionalButtonHandler(Direction.NorthWest); }
	void _on_button_turn_pressed() { endTurn(); }

	public override void _Ready()
	{
		Board = this.GetNode<Sprite2D>("Board");

		protagonist = Board.GetNode<Sprite2D>("Protagonist");

		MovedLabel = this.GetNode<RichTextLabel>("MovedLabel");
		PlacedLabel = this.GetNode<RichTextLabel>("PlacedLabel");
		ButtonTurn = this.GetNode<Button>("ButtonTurn");

		ButtonNorth     = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonNorth");
		ButtonNorthEast = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonNorthEast");
		ButtonEast      = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonEast");
		ButtonSouthEast = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonSouthEast");
		ButtonSouth     = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonSouth");
		ButtonSouthWest = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonSouthWest");
		ButtonWest	    = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonWest");
		ButtonNorthWest = protagonist.GetNode<Node2D>("DirectionButtons").GetNode<Button>("ButtonNorthWest");

		PawnTexture = GD.Load<Texture2D>("res://PawnSprite.png");

		Enemies = new List<Enemy>();
	}
	
	public override void _Process(double delta) { }
}

public partial class Enemy : Sprite2D
{
	public int PosX { get; set; }
	public int PosY { get; set; }
	public char Type { get; set; }

	public Enemy(int posX, int posY, char type = 'P')
	{
		PosX = posX;
		PosY = posY;
		Type = type;
	}
}*/
