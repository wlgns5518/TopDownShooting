using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private ProjectileManager projectileManager;
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public AudioClip shootingClip;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        projectileManager = ProjectileManager.instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        projectileManager.ShootBullet(
            projectileSpawnPosition.position,
            RotateVector2(aimDirection, angle),
            rangedAttackData
            );

        if (shootingClip)
            SoundManager.PlayClip(shootingClip);
    }

    private static Vector2 RotateVector2(Vector2 v,float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }

}
