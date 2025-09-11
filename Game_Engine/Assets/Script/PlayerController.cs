using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵� �ӵ�
    public float speed = 5f;

    // ���� ��
    public float jumpPower = 5f;

    // �߷� ��
    public float gravity = -9.81f;

    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private CharacterController controller;

    // ���� �ӵ� (Ư�� y�� ����/���Ͽ�)
    private Vector3 velocity;

    // ���� ��� �ִ��� ����
    private bool isGrounded;

    void Start()
    {
        // ������ �� CharacterController ������Ʈ�� ������
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ���� ��� �ִ��� üũ
        isGrounded = controller.isGrounded;

        // Ű���� �Է� (WASD �Ǵ� ����Ű) �ޱ�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �̵� ���� (x, z�ุ ���)
        Vector3 move = new Vector3(x, 0, z);

        // �̵� ó�� (�ӵ� * �ð� ����)
        controller.Move(move * speed * Time.deltaTime);

        // ���� �Է� ó�� (�����̽���)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpPower; // ���� �� y�ӵ� ����
        }

        // �߷� ����
        velocity.y += gravity * Time.deltaTime;

        // �߷�/���� ���� ���� �̵�
        controller.Move(velocity * Time.deltaTime);
    }
}
