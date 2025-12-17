using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    [SerializeField] private GameObject[] attackControllers;
    [SerializeField] private GameObject[] Punches;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackRate = 1.0f;
    [SerializeField] private float nextAttackTime = 0f;
    [SerializeField] private float nextComboTime = 0f;
    [SerializeField] private int comboStep = 0;
    private InputAction Attack;
    private PlayerMovement PMove;

    private void Awake()
    {
        Attack=PMove.playerInput.actions["Attack"];
    }

    private void Update()
    {
        int i = 0;

        if (PMove.toRight)
        {
            attackControllers[0].SetActive(true);
            attackControllers[1].SetActive(false);
            i = 0;
        }
        else
        {
            attackControllers[0].SetActive(false);
            attackControllers[1].SetActive(true);
            i = 1;
        }

        if (nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }

        if (Attack.WasPressedThisFrame() && nextAttackTime <= 0)
        {
            Punch(attackControllers[i]);
        }
    }

    void Punch(GameObject attackController)
    {
        Instantiate(Punches[0], attackController.transform);

        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.transform.position, attackRange);

        foreach (Collider2D obj in objects)
        {
            Health health = obj.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(attackDamage);
            }

            Rigidbody2D EnemyRb = obj.GetComponent<Rigidbody2D>();
            if (EnemyRb != null)
            {
                Vector2 knockbackDirection = (obj.transform.position - attackController.transform.position).normalized;
                float knockbackForce = 5f;
                EnemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }

        comboStep++;

        if (Attack.WasPressedThisFrame() && comboStep == 1)
        {
            Instantiate(Punches[1], attackController.transform);
            comboStep++;
        }
        else if (Attack.WasPressedThisFrame() && comboStep == 2)
        {
            Instantiate(Punches[2], attackController.transform);
            comboStep = 0;
            nextAttackTime = 1f / attackRate;
        }
        else
        {
            comboStep = 0;
            nextAttackTime = 1f / attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackControllers == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackControllers[0].transform.position, attackRange);
        Gizmos.DrawWireSphere(attackControllers[1].transform.position, attackRange);
    }
}
