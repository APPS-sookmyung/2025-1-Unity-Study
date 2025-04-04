using UnityEngine;
using UnityEngine.InputSystem;

// MonoBahaviour : ���� ���� ������ �ʿ��� �͵��� ���� Ŭ����
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
        // GetComponent<T> : ������Ʈ���� ������Ʈ�� �������� �Լ�, T �ڸ��� ������Ʈ �̸� �ۼ�
        // Player ����  Rigidbody2D�� ��������
        // �ʱ�ȭ
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   

    private void FixedUpdate()
    {
        // 1. ���� �ش�
        //rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        //rigid.linearVelocity = inputVec; 

        // 3. ��ġ �̵�
        // MovePosition�� ��ġ �̵��̶� ���� ��ġ�� �����־�� ��
        // fixedDeltaTime: ���� ������ �ϳ��� �Һ��� �ð�
        // input.GetAxis�� �Է� ���� �ε巴�� �ٲ�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    // ���� ���� ����, ��� �󿡼� �ٲ�� �������� ��� ������� ����!


    void OnMove(InputValue value)
    {
        // normalized applied by default
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        // LateUpdate : �������� ����Ǳ� ���� ����Ǵ� �����ֱ� �Լ�

        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; // True
        }
    }

}
