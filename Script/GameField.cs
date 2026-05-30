using Godot;
using System;

public partial class GameField : Node
{
	private static GameField _instance;
	public static GameField Instance => _instance ??= new GameField();
	private GameField() { }

	// Общая переменная
	public string ThemeColor { get; set; } = "Темная";

}