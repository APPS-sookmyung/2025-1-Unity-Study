using UnityEngine;

// MonoBahaviour : ���� ���� ������ �ʿ��� �͵��� ���� Ŭ����
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()

    {
        // GetComponent<T> : ������Ʈ���� ������Ʈ�� �������� �Լ�, T �ڸ��� ������Ʈ �̸� �ۼ�
        // Player ����  Rigidbody2D�� ��������
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // input: ����Ƽ���� �޴� ��� �Է��� �����ϴ� Ŭ����
        // which axis? Edit > Project Settings > Input Manager���� ��ư �̸� Ȯ��
        // input.GetAxis�� �Է� ���� �ε巴�� �ٲ�
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
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
}
