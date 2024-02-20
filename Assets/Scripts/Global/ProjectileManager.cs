using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem impactParticleSystem;

    public static ProjectileManager instance;

    private ObjectPool objectPool;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction,RangedAttackData rangedAttackData)
    {
        GameObject obj = objectPool.SpawnFromPool(rangedAttackData.bulletNameTag);
        obj.transform.position = startPosition;

        RangedAttackController rangedAttackController = obj.GetComponent<RangedAttackController>();
        rangedAttackController.InitializeAttack(direction,rangedAttackData,this);
        obj.SetActive(true);
    }

}
