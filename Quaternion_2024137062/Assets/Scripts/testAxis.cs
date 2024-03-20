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
        //raw는 -1, 0 ,1 만 잡기 때문에 속도가 일정함.
        //버튼이 눌렸는지 안 눌렸는지만 인식함,

        get = Input.GetAxis("Horizontal");
        //get은 속도가 천천히 올라가고 천천히 내려가서 더 부드러운 움직임을 만들어낼 수 있음.
    }
}
