public class RpnStack
{
	private readonly Stack<decimal> _stack = new Stack<decimal>();

	public void Push(decimal value)
	{
		_stack.Push(value);
	}

	public decimal Pop()
	{
		return _stack.Count > 0 ? _stack.Pop() : 0;
	}

	public decimal Peek(int index)
	{
		if (_stack.Count > index)
			return _stack.ToArray()[index];
		return 0;
	}

	public void Clear()
	{
		_stack.Clear();
	}

	public int Count => _stack.Count;
}
