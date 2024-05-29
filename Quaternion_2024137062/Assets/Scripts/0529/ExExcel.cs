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
            Debug.LogWarning("�������� �������");
            return;
            // Resources ���Ͽ� �����ϱ� �ҷ����� ������ ���� return�� ����� ��
        }

        itemDictionary.Clear();

        foreach (Entity_ItemData.Param param in item.sheets[0].list)        // ��Ʈ�� 1�����̹Ƿ� ��Ʈ ����Ʈ�� ù��°�� [0]�� ������
        {
            itemDictionary.Add(param.index, param);
            Debug.Log(param.itemName);
        }
    }

    private Entity_ItemData.Param FindItemFromDictionary(int number, bool isPrice = false) // bool isPrice = false ������ �Ű����� (�־ �ǰ� ��� ��)
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
