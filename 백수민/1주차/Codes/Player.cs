using UnityEngine;
using UnityEngine.InputSystem;

// MonoBahaviour : 게임 로직 구성에 필요한 것들을 가진 클래스
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()

    {
        // GetComponent<T> : 오브젝트에서 컴포넌트를 가져오는 함수, T 자리에 컴포넌트 이름 작성
        // Player 안의  Rigidbody2D를 가져오기
        // 초기화
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   

    private void FixedUpdate()
    {
        // 1. 힘을 준다
        //rigid.AddForce(inputVec);

        // 2. 속도 제어
        //rigid.linearVelocity = inputVec; 

        // 3. 위치 이동
        // MovePosition은 위치 이동이라 현재 위치도 더해주어야 함
        // fixedDeltaTime: 물리 프레임 하나가 소비한 시간
        // input.GetAxis는 입력 값이 부드럽게 바뀜
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    // 게임 실행 도중, 장면 상에서 바뀌는 정보들은 모두 사라지니 주의!


    void OnMove(InputValue value)
    {
        // normalized applied by default
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        // LateUpdate : 프레임이 종료되기 전에 실행되는 생명주기 함수

        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; // True
        }
    }

}
