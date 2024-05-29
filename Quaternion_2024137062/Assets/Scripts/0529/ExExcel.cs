using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExExcel : MonoBehaviour
{
    [HideInInspector] public Entity_ItemData item;
    public Dictionary<int, Entity_ItemData.Param> itemDictionary = new Dictionary<int, Entity_ItemData.Param>();

    public int indexNum;
    public int price;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        DataInDictionary();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(FindItemFromDictionary(indexNum, false).itemName + " : " + FindItemFromDictionary(indexNum).itemText);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(FindItemFromDictionary(itemName).itemName + " : " + FindItemFromDictionary(itemName).itemText);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(FindItemFromDictionary(price, true).itemName + " : " + FindItemFromDictionary(price, true).itemText);
        }
    }

    private void DataInDictionary()
    {
        if (item == null)
        {
            Debug.LogWarning("아이템이 비어있음");
            return;
            // Resources 파일에 있으니까 불러오는 로직을 쓰고 return을 지우면 됨
        }

        itemDictionary.Clear();

        foreach (Entity_ItemData.Param param in item.sheets[0].list)        // 시트가 1개뿐이므로 시트 리스트의 첫번째인 [0]을 쓴거임
        {
            itemDictionary.Add(param.index, param);
            Debug.Log(param.itemName);
        }
    }

    private Entity_ItemData.Param FindItemFromDictionary(int number, bool isPrice = false) // bool isPrice = false 선택적 매개변수 (있어도 되고 없어도 됨)
    {
        if (isPrice == true)
        {
            foreach (Entity_ItemData.Param item in itemDictionary.Values)
            {
                if (item.price == number)
                {
                    return item;
                }
            }
        }
        else
        {
            if (itemDictionary.ContainsKey(number))
            {
                return itemDictionary[number];
            }
        }

        return null;
    }

    private Entity_ItemData.Param FindItemFromDictionary(string name)
    {
        foreach (Entity_ItemData.Param item in itemDictionary.Values)
        {
            if (item.itemName == name)
            {
                return item;
            }
        }

        return null;
    }
}
