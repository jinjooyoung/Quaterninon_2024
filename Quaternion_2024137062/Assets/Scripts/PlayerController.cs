using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;            // rb�� RigidBody�� �Ȱ��� �����
    public int moveSpeed = 10;       // �÷��̾��� �̵��ӵ�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // rb�� ������Ʈ �ȿ� �ִ� rigidBody�� �־���        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove01(); //PlayerMove01�� �ּ�ó�������ν� ������� �ʰ� �����, PlayerMove02�� ����� �۵��ϴ��� �׽�Ʈ�غ�
        PlayerMove02();
    }

    public void PlayerMove01()      //�÷��̾��� ��ġ�� �ٲپ� �̵���Ű�� ����� �Լ�
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //�¿� �̵� �Է��� �޾ƿ�
        moveInput.y = Input.GetAxisRaw("Vertical");             //���� �̵� �Է��� �޾ƿ�

        moveInput.Normalize();                                  //�밢�� ���� ����
        transform.position += moveInput * moveSpeed * Time.deltaTime;        //�������� ��ȭ�ϴ��� �ӵ��� ����������
        //a=b a��b���� �־���, a+=b a�� b�� ������, a-=b a�� b�� ����
    }


    public void PlayerMove02()
    {
        Vector3 moveInput = new Vector3(0, 0, 0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //�¿� �̵� �Է��� �޾ƿ�
        moveInput.y = Input.GetAxisRaw("Vertical");             //���� �̵� �Է��� �޾ƿ�

        moveInput.Normalize();                                  //�밢�� ���� ����

        rb.velocity = moveInput * moveSpeed;        //rigidbody �ȿ� velocity�� ����
    }

    //PlayerMove01 �� PlayerMove02 �� ���� ���
    //transform.position �Լ�(PlayerMove01)�� rigidbody�� ��� �̵��� �� �ִ� �Լ��̰�
    //velocity �Լ�(PlayerMove02)�� rigidbody�� �־����� transform�Լ��� �̿����� �ʰ� �̵��ϰ� ���ִ� �Լ�
}
