using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptableObject", menuName = "Completo War PII Proyect/GunScriptableObject", order = 0)]
public class GunScriptableObject : ScriptableObject
{
    public float attackDamage = 1f;
    public float bulletSpeed = 70f;
    //public int spriteIndex = 0;
    public Sprite sprite;
    public Vector3 firePointPosition = new Vector3(0,0,0);
}
