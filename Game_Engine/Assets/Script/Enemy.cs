using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ===== �̵� ���� =====
    public float moveSpeed = 2f;   // �̵� �ӵ�
    private Transform player;      // �÷��̾� ������

    // ===== ü�� ���� =====
    public int maxHP = 5;          // �⺻ ü��
    private int currentHP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // ü�� �ʱ�ȭ
        currentHP = maxHP;
    }

    void Update()
    {
        if (player == null) return;

        // �÷��̾������ ���� ���ϱ�
        Vector3 direction = (player.position - transform.position).normalized;

        // �̵�
        transform.position += direction * moveSpeed * Time.deltaTime;

        // �÷��̾� �ٶ󺸱�
        transform.LookAt(player.position);
    }

    // ===== ������ ó�� �Լ� =====
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} �ǰ�! ���� ü��: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ���!");
        Destroy(gameObject);
    }
}
