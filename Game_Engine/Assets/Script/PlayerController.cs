using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 속도
    public float speed = 5f;

    // 점프 힘
    public float jumpPower = 5f;

    // 중력 값
    public float gravity = -9.81f;

    // 캐릭터 컨트롤러 컴포넌트
    private CharacterController controller;

    // 현재 속도 (특히 y축 점프/낙하용)
    private Vector3 velocity;

    // 땅에 닿아 있는지 여부
    private bool isGrounded;

    void Start()
    {
        // 시작할 때 CharacterController 컴포넌트를 가져옴
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 땅에 닿아 있는지 체크
        isGrounded = controller.isGrounded;

        // 키보드 입력 (WASD 또는 방향키) 받기
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 이동 방향 (x, z축만 고려)
        Vector3 move = new Vector3(x, 0, z);

        // 이동 처리 (속도 * 시간 보정)
        controller.Move(move * speed * Time.deltaTime);

        // 점프 입력 처리 (스페이스바)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpPower; // 점프 시 y속도 설정
        }

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;

        // 중력/점프 포함 최종 이동
        controller.Move(velocity * Time.deltaTime);
    }
}
