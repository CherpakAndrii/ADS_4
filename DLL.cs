namespace ADS_4
{
    public class DLL
    {
	    private int _size;
	    public Node First;
	    public Node Last;

	    public class Node
	    {
		    public double Value;
		    public Node Prev;
		    public Node Next;

		    public Node(double val)
		    {
			    Value = val;
			    Prev = Next = null;
		    }
	    }; 
	    public DLL() 
        {
			First = Last = null;
			_size = 0;
        }
	    public void PushBack(double val)
		{
			Node n = new Node(val);
			_size++;
			if (First == null)
			{
				First = Last = n;
			}
			else
			{
				Last.Next = n;
				n.Prev = Last;
				Last = n;
			}
		}

	    public void PushFront(double val)
		{
			Node n = new Node(val);
			_size++;
			if (First == null)
			{
				First = Last = n;
			}
			else
			{
				First.Prev = n;
				n.Next = First;
				First = n;
			}
		}

	    public double Delete(int ind)
		{
			Node n = First;
			if (ind < 0 && -ind <= _size) ind = _size - ind;
			if (ind > _size) return Last.Value;
			for (int ctr = 0; ctr < ind; ctr++) n = n.Next;
			n.Prev.Next = n.Next; 
			n.Next.Prev = n.Prev;
			_size--; 
			return n.Value;
		}

	    public void Insert(int ind, double val)
		{
			Node n = new Node(val);
			Node pos = First;
			if (ind < 0 && -ind <= _size) ind = _size - ind; 
			if (ind <= 0) PushFront(val);
			else if (ind>= _size) PushBack(val);
			else
			{ 
				for (int ctr = 1; ctr < ind; ctr++) pos = pos.Next;
				n.Next = pos.Next; 
				n.Next.Prev = n; 
				n.Prev = pos; 
				pos.Next = n; 
				_size++; 
			} 
		}

	    public double PopFront()
		{
			Node n = First;
			First.Next.Prev = null;
			First = First.Next;
			_size--;
			return n.Value;
		}

	    public double PopBack()
		{
			Node n = Last;
			Last.Prev.Next = null;
			Last = Last.Prev;
			_size--;
			return n.Value;
		}

	    public double this[int ind]
		{
			get
			{
				Node n = First;
				if (ind < 0 && -ind <= _size) ind = _size - ind;
				if (ind > _size) return Last.Value;
				for (int ctr = 0; ctr < ind; ctr++) n = n.Next;
				return n.Value;
			}
		}

	    public int get_size()
	    {
		    return _size;
	    }
    }
}