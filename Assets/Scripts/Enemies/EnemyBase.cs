using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;
using UnityEngine.Events;



namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider mycollider;
        public FlashColor flashColor;
        public ParticleSystem myparticleSystem;

        public float startLife = 10f;
        public bool lookAtPlayer = false;

        [SerializeField]private float _currentLife;

        [Header("Animation")]
        [SerializeField]private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        [Header("Events")]
        public UnityEvent OnKillEvent;

        private PlayerController _player;


        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<PlayerController>();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }


        protected virtual void Init()
        {
            ResetLife();


            if(startWithBornAnimation)
                BornAnimation();
        }


        protected virtual void Kill() 
        {

            OnKill();
        }


        protected virtual void OnKill() 
        {
            if (mycollider != null) mycollider.enabled = false;
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
            OnKillEvent?.Invoke();
        }

        public void OnDamage(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (myparticleSystem != null) myparticleSystem.Emit(15);

            transform.position -= transform.forward;

            _currentLife -= f;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        #endregion


       /* private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }
        }*/

        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage);
        }

        public void Damage(float damage, Vector3 dir)
        {

            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }


        private void OnCollisionEnter(Collision collision)
        {
            PlayerController p = collision.transform.GetComponent<PlayerController>();

            if(p != null)
            {
                p.healthBase.Damage(1);
            }
        }

        public virtual void Update()
        {
            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }
    }
}
