using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAxis : MonoBehaviour
{
    public float raw;
    public float get;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raw = Input.GetAxisRaw("Horizontal");
        //raw�� -1, 0 ,1 �� ��� ������ �ӵ��� ������.
        //��ư�� ���ȴ��� �� ���ȴ����� �ν���,

        get = Input.GetAxis("Horizontal");
        //get�� �ӵ��� õõ�� �ö󰡰� õõ�� �������� �� �ε巯�� �������� ���� �� ����.
    }
}
