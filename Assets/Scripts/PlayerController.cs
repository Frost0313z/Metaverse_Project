using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D _rigidbody; // 충돌 구현해야 하니까
    [SerializeField] private SpriteRenderer characterRenderer; // 캐릭터 스프라이트 이미지 필요하니까
    private Vector2 knockback = Vector2.zero;
    [SerializeField] private float characterMoveSpeed = 1f;
    [SerializeField] private float characterKnockback = 0.5f;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void OnMove(InputValue inputValue)
    {
        Vector2 direction = inputValue.Get<Vector2>().normalized;
        direction = direction * characterMoveSpeed;

        if(direction.x != 0) // 플립
        {
            if(direction.x < 0)
            characterRenderer.flipX = true;
            else
            characterRenderer.flipX = false;
        }

        if(knockbackDuration > 0f) // 넉백
        {
            direction *= characterKnockback;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
    }


    private void OnInteract(InputValue inputValue)
    {
        // F키 누르면 상호작용 하도록 구현현

    }

    private void OnJump(InputValue inputValue)
    {
        // 그라운드 만들고 리지드 바디 넣어야함함
        // 점프하는 애니메이션 출력하기
    }

}
