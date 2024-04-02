using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public float damage;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackRadius;
    [SerializeField] public LayerMask enemyLayer;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = health;
    }

    private void Update()
    {
        if (_currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    public void Attack(Vector2 dir)
    {
        var hit = Physics2D.CircleCast(transform.position, attackRadius, dir, attackRange, enemyLayer);
        if (hit)
        {
            hit.collider.GetComponent<Unit>()?.TakeDamage(damage);
        }
    }

    public void TakeDamage(float d)
    {
        _currentHealth -= d;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.up * attackRange, attackRadius);
    }
}