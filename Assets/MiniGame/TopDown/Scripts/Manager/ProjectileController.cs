using UnityEngine;

namespace MiniGame.TopDown
{
    public class ProjectileController : MonoBehaviour // 투사체 컨트롤하는 스크립트트
    {
        [SerializeField] private LayerMask levelCollisionLayer;

        private RangeWeaponHandler rangeWeaponHandler;

        private float currentDuration;
        private Vector2 direction;
        private bool isReady;
        private Transform pivot;

        private Rigidbody2D _rigidbody;
        private SpriteRenderer spriteRenderer;

        public bool fxOnDestory = true; // 삭제시 이펙트 출력 여부 판단
        ProjectileManager projectileManager;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            pivot = transform.GetChild(0);
        }

        private void Update()
        {
            if (!isReady)
            {
                return;
            }

            currentDuration += Time.deltaTime;

            if (currentDuration > rangeWeaponHandler.Duration)
            {
                DestroyProjectile(transform.position, false);
            }

            _rigidbody.velocity = direction * rangeWeaponHandler.Speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer))) // 합체한 다음 포함하는 지 체크하는 거임
            {
                DestroyProjectile(collision.ClosestPoint(transform.position) - direction * .2f, fxOnDestory);
            }
            else if (rangeWeaponHandler.target.value == (rangeWeaponHandler.target.value | (1 << collision.gameObject.layer)))
            {
                ResourceController resourceController = collision.GetComponent<ResourceController>();
                if (resourceController != null)
                {
                    resourceController.ChangeHealth(-rangeWeaponHandler.Power);
                    if (rangeWeaponHandler.IsOnKnockback)
                    {
                        BaseController controller = collision.GetComponent<BaseController>();
                        if (controller != null)
                        {
                            controller.ApplyKnockback(transform, rangeWeaponHandler.KnockbackPower, rangeWeaponHandler.KnockbackTime);
                        }
                    }
                }
                DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
            }
        }


        public void Init(Vector2 direction, RangeWeaponHandler weaponHandler, ProjectileManager projectileManager)
        {
            this.projectileManager = projectileManager;
            rangeWeaponHandler = weaponHandler;

            this.direction = direction;
            currentDuration = 0;
            transform.localScale = Vector3.one * weaponHandler.BulletSize;
            spriteRenderer.color = weaponHandler.ProjectileColor;

            transform.right = this.direction;

            if (this.direction.x < 0)
                pivot.localRotation = Quaternion.Euler(180, 0, 0);
            else
                pivot.localRotation = Quaternion.Euler(0, 0, 0);

            isReady = true;
        }

        private void DestroyProjectile(Vector3 position, bool createFx)
        {
            if (createFx)
            {
                projectileManager.CreateImpactParticlesAtPostion(position, rangeWeaponHandler);
            }
            Destroy(this.gameObject);
        }
    }
}
