using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedString
{
    public sealed class SquareList<T> where T : new()
    {
        private List<T> _InternalList = new List<T>();
        private T[,] _InternalArray;
        private int _Rank;

        public SquareList(int size)
        {
            //if (size == 0)
            //    return;
            _InternalArray = new T[size, size];
            _Rank = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _InternalArray[i, j] = new T();
                }
            }
        }

        public SquareList() : this(0)
        {

        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _InternalList.Count)
                    return _InternalList[index];
                else
                    throw new IndexOutOfRangeException("Out of range");
            }

            set
            {
                if (index >= 0 && index < _InternalList.Count)
                    _InternalList[index] = (T)value;
                else
                    throw new IndexOutOfRangeException("Out of range");
            }
        }

        public T this[int i,int j]
        {
            get
            {
                if (i >= 0 && i < _Rank && j >= 0 && j < _Rank)
                {
                    return _InternalArray[i, j];
                }
                else
                    throw new IndexOutOfRangeException("Out of range");
            }
            set
            {
                if (i >= 0 && i < _Rank && j >= 0 && j < _Rank)
                {
                    _InternalArray[i, j] = (T)value;
                }
                else
                    throw new IndexOutOfRangeException("Out of range");
            }
        }

        

        public int Count
        {
            get
            {
                return _InternalArray.Length;
            }
        }

        public int Rank
        {
            get { return _Rank; }
        }

        public int Add()
        {
            if (_Rank == 0)
            {
                _Rank++;
                _InternalArray = new T[1, 1];
                _InternalArray[0, 0] = new T();
            }
            else
            {
                int oldRank = _Rank;
                _Rank++;
                T[,] newSquareArray = new T[_Rank, _Rank];
                for (int i = 0; i < oldRank; i++)
                {
                    for (int j = 0; j < oldRank; j++)
                    {
                        newSquareArray[i, j] = _InternalArray[i, j];
                    }
                }
                int LastIndex = _Rank - 1;
                for (int i = 0; i < _Rank; i++)
                {
                    if (i == _Rank - 1)
                    {
                        for (int j = 0; j < _Rank; j++)
                        {
                            newSquareArray[i, j] = new T();
                        }
                    }
                    else
                    {
                        newSquareArray[i, LastIndex] = new T();
                    }
                }
                _InternalArray = newSquareArray;
            }
            return _Rank;
        }

        public void AddMany(int Count)
        {
            if (_Rank == 0)
            {
                _Rank = Count;
                _InternalArray = new T[_Rank, _Rank];
                for (int i = 0; i < _Rank; i++)
                {
                    for (int j = 0; j < _Rank; j++)
                    {
                        _InternalArray[i, j] = new T();
                    }
                }
            }
            else
            {
                int oldRank = _Rank;
                _Rank += Count;
                T[,] newSquareArray = new T[_Rank, _Rank];
                for (int i = 0; i < _Rank; i++)
                {
                    for (int j = 0; j < _Rank; j++)
                    {
                        if (i < oldRank && j < oldRank)
                        {
                            newSquareArray[i, j] = _InternalArray[i, j];
                        }
                        else
                        {
                            newSquareArray[i, j] = new T();
                        }
                    }
                }
                _InternalArray = newSquareArray;
            }
        }

        public void Clear()
        {
            _InternalArray = null;
            _InternalList = null;
        }

        public void RemoveAt(int index)
        {
            int OldRank = _Rank;
            _Rank--;
            T[,] newSquareList = new T[_Rank, _Rank];
            int i = 0;
            int j = 0;
            for (int oldi = 0; oldi < OldRank; oldi++)
            {
                if (oldi == index)
                    continue;
                for (int oldj = 0; oldj < OldRank; oldj++)
                {
                    if (oldj == index)
                        continue;
                    if (i < _Rank && j < _Rank)
                    {
                        newSquareList[i, j] = _InternalArray[oldi, oldj];
                        j++;
                    }
                    else
                        break;
                }
                i++;
            }
            _InternalArray = newSquareList;
        }

        public void RemoveAtRange(int index, int count = 1)
        {
            int oldRank = _Rank;
            _Rank -= count;
            T[,] newSquareList = new T[_Rank, _Rank];
            int i = 0;
            for (int oldi = 0; oldi < oldRank; oldi++)
            {
                int j = 0;
                if (oldi >= index && oldi < index + count)
                    continue;
                for (int oldj = 0; oldj < oldRank; oldj++)
                {
                    if (oldj >= index && oldj < index + count)
                        continue;
                    if (i < _Rank && j < _Rank)
                    {
                        newSquareList[i, j] = _InternalArray[oldi, oldj];
                        j++;
                    }
                    else
                        continue;
                }
                i++;
            }
            _InternalArray = newSquareList;
        }
    }
}
