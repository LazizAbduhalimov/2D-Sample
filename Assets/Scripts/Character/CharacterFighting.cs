using System;
using UnityEngine;

public class CharacterFighting : MonoBehaviour, IFigthtable
{
    [SerializeField] private Transform _attackTransform;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRadius;
    private int _health;
    public int Health 
    { 
        get => _health; 
        set 
        {
            _health = value;
            if (_health <= 0) Die();
        } 
    }
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        var enemies = Physics2D.OverlapCircleAll(_attackTransform.position, _attackRadius, _enemyLayer);
        foreach(var enemy in enemies)
        {
            Debug.Log(enemy.name);
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

        Health -= damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackTransform.position, _attackRadius);
    }
}
