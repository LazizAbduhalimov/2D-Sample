using System;
using UnityEngine;

public class CharacterCombat : MonoBehaviour, IFigthtable
{
    [SerializeField] private Transform _attackTransform;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRate = 0.5f;

    private float _nextAttackTime = 0f;
    private int _currentHealth;
    private Animator _animator;


    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        if (Time.time > _nextAttackTime) 
        {
            AttackInternal();
            _nextAttackTime = Time.time + _attackRate;
        }
    }

    private void AttackInternal()
    {
        _animator.SetTrigger("Attack");
        var enemies = Physics2D.OverlapCircleAll(_attackTransform.position, _attackRadius, _enemyLayer);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<IEnemy>().TakeDamage(_damage);
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Death");
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) 
            throw new ArgumentException($"The object({gameObject.name} can't take negative damage");

        _animator.SetTrigger("Hurt");
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackTransform.position, _attackRadius);
    }
}
