using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.Flappy
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D _rigidbody;

        public float flapForce = 6f;
        public float forwardSpeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f;

        bool isFlap = false;

        public bool godMode = false;

        GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameManager.Instance;

            animator = GetComponentInChildren<Animator>(); // 자식 오브젝트의 애니메이터 찾기기
            _rigidbody = GetComponent<Rigidbody2D>(); // 컴포넌트를 반환하는 함수

            if (animator == null)
                Debug.LogError("Not Founded Animator");

            if (_rigidbody == null)
                Debug.LogError("Not Founded Rigidbody");

        }

        // Update is called once per frame
        void Update()
        {
            if (isDead)
            {
                if (deathCooldown <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        gameManager.RestartGame();
                    }
                    // 게임 재시작 코드 작성
                }
                else
                {
                    deathCooldown -= Time.deltaTime; // deltaTime은 이전 프레임과 현재 프레임 간의 시간을 의미, 실제 누적 시간 및 성능 다른 컴퓨터도 이동하는 값을 맞출때 사용함
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // 스페이스나 클릭시 플립함함
                {
                    isFlap = true;
                }

            }

        }

        private void FixedUpdate()
        {
            if (isDead) return; // 죽으면 움직이지 않음

            Vector3 velocity = _rigidbody.velocity; // rigidbody의 속도를 가져온다는 변수 선언언
            velocity.x = forwardSpeed; // x축 속도를 일정한 값으로 고정한다.

            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity; // 속도를 실제로 적용한다다

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); // 각도 -90도에서 90도로 제한하기
            transform.rotation = Quaternion.Euler(0, 0, angle); // Z축 회전
        }

        private void OnCollisionEnter2D(Collision2D collision) // 플레이어가 무언가에 부딪히는 경우우
        {
            if (godMode) return;

            if (isDead) return; // 중복 사망 방지

            isDead = true; // 사망 상태 플래그 설정
            deathCooldown = 1f; // 죽은 뒤 일정 시간 딜레이이

            animator.SetInteger("IsDie", 1); // 애니메이터에 죽음 상태 전달하기
            gameManager.GameOver();
        }
    }
}
