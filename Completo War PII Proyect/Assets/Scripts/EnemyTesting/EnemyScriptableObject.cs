using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Completo War PII Proyect/EnemyScriptableObject", order = 0)]
public class EnemyScriptableObject : ScriptableObject 
{
    public int shootsPerAttack = 3;
    public float bulletSpeed = 70f;
    public float cadencyTime = 0.3f;
    public float CoolDownTime = 3f;

}