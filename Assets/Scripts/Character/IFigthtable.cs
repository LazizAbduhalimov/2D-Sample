public interface IFigthtable
{
    int Health { get; set; }
    void Attack();
    void TakeDamage(int damage);
    void Die();
}
