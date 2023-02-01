using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    private Animator _animator;


    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponentInChildren<Animator>();
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

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
