using UnityEngine;

[CreateAssetMenu(fileName = "AttackScriptableObject", menuName = "Completo War PII Proyect/AttackScriptableObject", order = 0)]
public class AttackScriptableObject : ScriptableObject
{
    public float attackRange = 100f;
    public int shootsPerAttack = 3;
    public float cadencyTime = 0.3f;
    public float coolDownTime = 3f;
    public int bulletsPerShoot = 1;
    public float angle = 0f;
}
