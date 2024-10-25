using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data;

namespace MauiRPNCalculator;

public partial class MainPageViewModel : ObservableObject
{
	[ObservableProperty]
	private string _row1;

	[ObservableProperty]
	private string _row2;

	[ObservableProperty]
	private string _row3;

	[ObservableProperty]
	private string _row4;

	[ObservableProperty]
	private string _result;

	[RelayCommand]
	public void HandleNumberButtonPress(string buttonText)
	{
		Result = (Result + buttonText);
	}
	[RelayCommand]
	public void HandleOperatorButtonPress(string buttonText)
	{
		if (buttonText == "Del")
		{
			if (!string.IsNullOrWhiteSpace(Result))
			{
				Result = Result.Substring(0, Result.Length - 1);
			}
			else if (!string.IsNullOrWhiteSpace(Row1))
			{
				Row1 = Row2;
				Row2 = Row3;
				Row3 = Row4;
				Row4 = "";
			}
		}
		else if (buttonText == "Enter")
		{
			if (!string.IsNullOrWhiteSpace(Result))
			{
				Row4 = Row3;
				Row3 = Row2;
				Row2 = Row1;
				Row1 = Result;
				Result = "";
			}
			else
			{
				Row4 = Row3;
				Row3 = Row2;
				Row2 = Row1;
			}
		}
		else if (buttonText == "+")
		{
			if (!string.IsNullOrWhiteSpace(Result))
			{
				Row1 = ($"{decimal.Parse(Row1) + decimal.Parse(Result)}");
				Result = "";
			}
			else if (!string.IsNullOrWhiteSpace(Row1) && !string.IsNullOrWhiteSpace(Row2))
			{
				Row1 = ($"{decimal.Parse(Row1) + decimal.Parse(Row2)}");
				Row2 = Row3;
				Row3 = Row4;
				Row4 = "";
			}
		}
		else if (buttonText == "-")
		{
            if (!string.IsNullOrWhiteSpace(Result))
            {
                Row1 = ($"{decimal.Parse(Row1) - decimal.Parse(Result)}");
                Result = "";
            }
            else if (!string.IsNullOrWhiteSpace(Row1) && !string.IsNullOrWhiteSpace(Row2))
            {
                Row1 = ($"{decimal.Parse(Row1) - decimal.Parse(Row2)}");
                Row2 = Row3;
                Row3 = Row4;
                Row4 = "";
            }

        }
		else if (buttonText == "x")
		{
            if (!string.IsNullOrWhiteSpace(Result))
            {
                Row1 = ($"{decimal.Parse(Row1) * decimal.Parse(Result)}");
                Result = "";
            }
            else if (!string.IsNullOrWhiteSpace(Row1) && !string.IsNullOrWhiteSpace(Row2))
            {
                Row1 = ($"{decimal.Parse(Row1) * decimal.Parse(Row2)}");
                Row2 = Row3;
                Row3 = Row4;
                Row4 = "";
            }
        }
		else if (buttonText == "÷")
		{
            if (!string.IsNullOrWhiteSpace(Result))
            {
                Row1 = ($"{decimal.Parse(Row1) / decimal.Parse(Result)}");
                Result = "";
            }
            else if (!string.IsNullOrWhiteSpace(Row1) && !string.IsNullOrWhiteSpace(Row2))
            {
                Row1 = ($"{decimal.Parse(Row1) / decimal.Parse(Row2)}");
                Row2 = Row3;
                Row3 = Row4;
                Row4 = "";
            }
        }
		else if (buttonText == "%")
		{

		}
		else if (buttonText == "√")
		{

		}
		else if(buttonText == "Clear")
		{
            Row4 = "";
            Row3 = "";
            Row2 = "";
            Row1 = "";
            Result = "";
        }
	}
}