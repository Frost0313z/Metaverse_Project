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
    private GameObject currentInteractable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 direction = inputValue.Get<Vector2>().normalized;
        direction = direction * characterMoveSpeed;

        if (direction.x != 0 || direction.y != 0)
        {
            animator.SetBool("IsMove", true);
            if (direction.x != 0) // 플립
            {
                if (direction.x < 0)
                    characterRenderer.flipX = true;
                else
                    characterRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        _rigidbody.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision) // 상호작용 물체를 인식하여 변수에 저장한다.
    {
        if (collision.CompareTag("NPC") ||
        collision.CompareTag("Minigame_trigger") ||
        collision.CompareTag("Monster"))
        {
            currentInteractable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 상호작용 물체에서 멀어지면 초기화 해주자~!
    {
        if (currentInteractable != null && collision.gameObject == currentInteractable)
        {
            currentInteractable = null;
        }
    }

    private void OnInteract(InputValue inputValue) // F키를 누를경우
    {
        if (currentInteractable == null)
            return;

        string tag = currentInteractable.tag;

        if (tag == "NPC") { }
        if (tag == "Monster") { }
        if (tag == "Minigame_trigger") { }
    }

}
