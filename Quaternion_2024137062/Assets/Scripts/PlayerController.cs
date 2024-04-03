using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;            // rb�� RigidBody�� �Ȱ��� �����
    public StatData player;
    public float attackCooldown;
    public float currentColldown;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // rb�� ������Ʈ �ȿ� �ִ� rigidBody�� �־���        
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove01(); //PlayerMove01�� �ּ�ó�������ν� ������� �ʰ� �����, PlayerMove02�� ����� �۵��ϴ��� �׽�Ʈ�غ�
        PlayerMove02();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void PlayerMove01()      //�÷��̾��� ��ġ�� �ٲپ� �̵���Ű�� ����� �Լ�
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //�¿� �̵� �Է��� �޾ƿ�
        moveInput.z = Input.GetAxisRaw("Vertical");             //���� �̵� �Է��� �޾ƿ�

        moveInput.Normalize();                                  //�밢�� ���� ����
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;        //�������� ��ȭ�ϴ��� �ӵ��� ����������
        //a=b a��b���� �־���, a+=b a�� b�� ������, a-=b a�� b�� ����
    }


    public void PlayerMove02()
    {
        Vector3 moveInput = new Vector3(0, 0, 0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //�¿� �̵� �Է��� �޾ƿ�
        moveInput.z = Input.GetAxisRaw("Vertical");             //���� �̵� �Է��� �޾ƿ�

        moveInput.Normalize();                                  //�밢�� ���� ����

        rb.velocity = moveInput * player.moveSpeed;        //rigidbody �ȿ� velocity�� ����
    }

    //PlayerMove01 �� PlayerMove02 �� ���� ���
    //transform.position �Լ�(PlayerMove01)�� rigidbody�� ��� �̵��� �� �ִ� �Լ��̰�
    //velocity �Լ�(PlayerMove02)�� rigidbody�� �־����� transform�Լ��� �̿����� �ʰ� �̵��ϰ� ���ִ� �Լ�

    public void FireProjectile()
    {
        GameObject temp = Managers.Pool.Pop(bullet);
        BulletController bc = temp.GetComponent<BulletController>();

        temp.transform.position = this.gameObject.transform.position;
        bc.direction = Vector3.forward;
        bc.damage = player.bulletDamage;
        bc.moveSpeed = player.bulletLevel;

        Managers.Data.Bullets.Add(bc);
    }
}
