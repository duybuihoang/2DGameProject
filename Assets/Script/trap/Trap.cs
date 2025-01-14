using DuyBui;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damageRadius = 0.5f;        // Bán kính tác động của bẫy
    public int trapDamage = 10;           // Sát thương của bẫy
    public float knockbackStrength = 5f;  // Lực đẩy lùi (nếu cần)
    public LayerMask targetLayer;         // Lớp mục tiêu bị tác động (ví dụ: Player)

    private void ActivateTrap()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, damageRadius);

        foreach (var item in targets)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(trapDamage);
            }

            if (item.TryGetComponent(out IKnockbackable knockbackable))
            {
                Vector2 knockbackDirection = (item.transform.position - transform.position).normalized;
                knockbackable.KnockBack(knockbackDirection, knockbackStrength);
            }
        }

       
        TriggerEffects();
    }

    private void TriggerEffects()
    {
        // Thêm hiệu ứng hạt, âm thanh, v.v.
        Debug.Log("Trap activated!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kích hoạt bẫy khi nhân vật chạm vào
        if (((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            ActivateTrap();
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Hiển thị bán kính tác động của bẫy trong chế độ Scene
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
