using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ===== 이동 관련 =====
    public float moveSpeed = 2f;   // 이동 속도
    private Transform player;      // 플레이어 추적용

    // ===== 체력 관련 =====
    public int maxHP = 5;          // 기본 체력
    private int currentHP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 체력 초기화
        currentHP = maxHP;
    }

    void Update()
    {
        if (player == null) return;

        // 플레이어까지의 방향 구하기
        Vector3 direction = (player.position - transform.position).normalized;

        // 이동
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 플레이어 바라보기
        transform.LookAt(player.position);
    }

    // ===== 데미지 처리 함수 =====
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} 피격! 현재 체력: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} 사망!");
        Destroy(gameObject);
    }
}
