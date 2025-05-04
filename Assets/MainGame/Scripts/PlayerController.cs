using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer characterRenderer;
    private Vector2 knockback = Vector2.zero;
    [SerializeField] private float characterMoveSpeed = 1f;
    private Animator animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 direction = inputValue.Get<Vector2>().normalized;
        direction = direction * characterMoveSpeed;

        if(direction.x != 0 || direction.y != 0)
        {
            animator.SetBool("IsMove", true);
            if(direction.x != 0) // 플립
            {
                if(direction.x < 0)
                characterRenderer.flipX = true;
                else
                characterRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("IsMove",false);
        }

        _rigidbody.velocity = direction;
    }


    private void OnInteract(InputValue inputValue)
    {
        // F키 누르면 상호작용 하도록 구현

    }

    private void OnJump(InputValue inputValue)
    {
        // 그라운드 만들고 리지드 바디 넣어야함
        // 점프하는 애니메이션 출력하기
    }

}
