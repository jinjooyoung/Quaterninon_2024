using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ListTest : MonoBehaviour
{
    public MyList<Player> playerList = new MyList<Player>();        // 리스트를 만들 초기식 playerList는 이름일 뿐이고 앞에서 타입을 받아옴
    public Player player = new Player(0, "동글이", 2);          // 밑에 플레이어 클래스에서 설정한 id, name, level을 인수로 받아와서 player를 쉽게 만듦
    public Player player2 = new Player(1, "세모", 3);

    // Start is called before the first frame update
    void Start()
    {
        playerList.Add(player);                                 // 리스트에 플레이어를 추가
        playerList.Add(player2);

        Debug.Log(playerList[0].name);                          // 동글이
        Debug.Log(playerList[1].name);                          // 세모
        Debug.Log(playerList.Count);                            // 2
        Debug.Log(playerList[3].name);                          // 오류
    }
}

[System.Serializable]

public class Player
{
    public int id;
    public string name;
    public int level;

    public Player(int id, string name, int level)
    {
        this.id = id;
        this.name = name;
        this.level = level;
    }
}

public class MyList<T>
{
    private T[] _items;
    private int _size;

    public MyList()
    {
        _items = new T[4];
        _size = 0;
    }

    public int Count
    {
        get { return _size; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_size == _items.Length)
        {
            Resize(_size * 2);
        }

        _items[_size++] = item;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        _size--;

        for (int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = default(T);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (Equals(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void Clear()
    {
        _items = new T[4];
        _size = 0;
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(_items, newArray, _size);
        _items = newArray;
    }
}