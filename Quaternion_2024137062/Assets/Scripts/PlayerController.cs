using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;            // rb를 RigidBody와 똑같이 취급함
    public StatData player;
    public float attackCooldown;
    public float currentColldown;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // rb에 오브젝트 안에 있는 rigidBody를 넣어줌        
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove01(); //PlayerMove01를 주석처리함으로써 기능하지 않게 만들어, PlayerMove02가 제대로 작동하는지 테스트해봄
        PlayerMove02();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void PlayerMove01()      //플레이어의 위치를 바꾸어 이동시키게 만드는 함수
    {
        Vector3 moveInput = new Vector3(0,0,0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //좌우 이동 입력을 받아옴
        moveInput.z = Input.GetAxisRaw("Vertical");             //상하 이동 입력을 받아옴

        moveInput.Normalize();                                  //대각선 가속 방지
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;        //프레임이 변화하더라도 속도를 유지시켜줌
        //a=b a에b값을 넣어줌, a+=b a에 b를 더해줌, a-=b a에 b를 빼줌
    }


    public void PlayerMove02()
    {
        Vector3 moveInput = new Vector3(0, 0, 0);

        moveInput.x = Input.GetAxisRaw("Horizontal");           //좌우 이동 입력을 받아옴
        moveInput.z = Input.GetAxisRaw("Vertical");             //상하 이동 입력을 받아옴

        moveInput.Normalize();                                  //대각선 가속 방지

        rb.velocity = moveInput * player.moveSpeed;        //rigidbody 안에 velocity가 있음
    }

    //PlayerMove01 과 PlayerMove02 는 같은 기능
    //transform.position 함수(PlayerMove01)는 rigidbody가 없어도 이동할 수 있는 함수이고
    //velocity 함수(PlayerMove02)는 rigidbody를 넣었을때 transform함수를 이용하지 않고 이동하게 해주는 함수

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
