using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //evnet �ܺο����� ȣ������ ���ϰ� ���´�.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected CharacterStatsHandler Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;

        if (timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        if(IsAttacking && timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}


//{
//    [SerializeField]
//    private float speed = 5.0f;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //float x = Input.GetAxisRaw("Horizontal");
//        //float y = Input.GetAxisRaw("Vertical");

//        //transform.position += new Vector3(x, y)*speed * Time.deltaTime;
//    }
//}
