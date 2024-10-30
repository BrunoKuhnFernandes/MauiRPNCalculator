using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data;

namespace MauiRPNCalculator.Mvvm.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
	private readonly RpnStack _stack = new RpnStack();

	[ObservableProperty]
	private string _row1;

	[ObservableProperty]
	private string _row2;

	[ObservableProperty]
	private string _row3;

	[ObservableProperty]
	private string _row4;

	[ObservableProperty]
	private string _TypingField;

	public MainPageViewModel()
	{
		UpdateRows();
	}

	[RelayCommand]
	public void HandleNumberButtonPress(string buttonText)
	{
		TypingField = (TypingField + buttonText);
	}

	[RelayCommand]
	public void HandleOperatorButtonPress(string buttonText)
	{
		if (buttonText == "Del")
		{
			if (!string.IsNullOrWhiteSpace(TypingField))
			{
				TypingField = TypingField.Substring(0, TypingField.Length - 1);
			}
			else
			{
				_stack.Pop();
				UpdateRows();
			}
		}
		else if (buttonText == "Enter")
		{
			if (!string.IsNullOrWhiteSpace(TypingField))
			{
				_stack.Push(decimal.Parse(TypingField));
				TypingField = "";
				UpdateRows();
			}
			else
			{
				_stack.Push(_stack.Peek(0));
				UpdateRows();
			}
		}
		else if (buttonText == "+" && _stack.Count >= 2)
		{
			PerformOperation((a, b) => a + b);
		}
		else if (buttonText == "-" && _stack.Count >= 2)
		{
			PerformOperation((a, b) => b - a); // Inverter para operação correta
		}
		else if (buttonText == "x" && _stack.Count >= 2)
		{
			PerformOperation((a, b) => a * b);
		}
		else if (buttonText == "÷" && _stack.Count >= 2)
		{
			PerformOperation((a, b) => b / a); // Inverter para operação correta
		}
		else if (buttonText == "Clear")
		{
			_stack.Clear();
			TypingField = "";
			UpdateRows();
		}
	}

	private void PerformOperation(Func<decimal, decimal, decimal> operation)
	{
		var a = _stack.Pop();
		var b = _stack.Pop();
		_stack.Push(operation(a, b));
		UpdateRows();
	}

	private void UpdateRows()
	{
		Row1 = _stack.Count > 0 ? _stack.Peek(0).ToString() : "";
		Row2 = _stack.Count > 1 ? _stack.Peek(1).ToString() : "";
		Row3 = _stack.Count > 2 ? _stack.Peek(2).ToString() : "";
		Row4 = _stack.Count > 3 ? _stack.Peek(3).ToString() : "";
	}
}
