using KHG.Interface;
using UnityEngine;

namespace KHG.Obstacles
{
    public class Cannon : BaseObstacle
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float fireInterval = 2f;
        [SerializeField] private Vector3 scaleVariation = new Vector3(1.5f, 1.5f, 1.5f);

        [SerializeField] private Transform firePos;


        private bool _isActive;
        private float timer;

        public override void Initialize()
        {
            base.Initialize();
            timer = 0f;
        }

        public override void Activate()
        {
            base.Activate();
            _isActive = true;
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _isActive = false;
        }
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= fireInterval)
            {
                timer = 0f;
                FireProjectile();
            }
        }

        void FireProjectile()
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            if(bullet.TryGetComponent(out IThrowable throwable))
            {
                Vector3 direction = (firePos.position - transform.position).normalized;
                throwable.Throw(direction, 10f);
            }
            bullet.transform.position = firePos.position;
            bullet.transform.localScale = scaleVariation * Random.Range(0.8f, 1.2f);
        }
    }
}