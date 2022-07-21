using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class EnemyScript : Entity
{
    [Space]
    [Header("Scripts: ")]
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyMovement enemyMovement;


    [SerializeField] private int timesToRepeat = 1;
    [SerializeField] private float moveTime, attackTime, coolDownTime;

    [Header("Events: ")]
    [SerializeField] private UnityEvent OnDie;
    [SerializeField] private UnityEvent OnStart;
    [SerializeField] private UnityEvent OnMove;
    [SerializeField] private UnityEvent OnAttack;
    [SerializeField] private UnityEvent OnRest;

    /*[Header("Die: ")]
    [SerializeField] private AudioClip defeatClip;
    [SerializeField] private Sprite defeatedSprite;
    [SerializeField] private GameObject defeatedPrefab;*/
    [SerializeField] private GameObject dropPrefab;

    private bool isReady = true;
    private WaitForSeconds waitMove, waitAttack, waitCoolDown;

    void Start(){
        //enemyMovement = GetComponent<EnemyMovement>();
        //enemyAttack = GetComponent<EnemyAttack>();

        //SetTarget(FindClosestPlayer().transform);
        //enemyMovement.Initialize();
        //enemyAttack.Initialize();

        SetWaits();
        OnStart?.Invoke();//Para llamar a la room
    }

    void Update(){
        //SetTarget(FindClosestPlayer().transform);

        //enemyMovement.Move();
        //enemyAttack.Attack();

        if(isReady){
            StartCoroutine(Pattern());
        }
    }

    IEnumerator Pattern(){
        isReady = false;

        for(int i=0;i<timesToRepeat;i++){
            OnMove?.Invoke();
            yield return waitMove;
            OnAttack?.Invoke();
            yield return waitAttack;
        }
        OnRest?.Invoke();
        yield return waitCoolDown;

        isReady = true;
    }

    public override void Die(){
        /*GameObject defeated = Instantiate(defeatedPrefab,transform.position,transform.rotation);
        defeated.GetComponent<AudioSource>().clip = defeatClip;
        defeated.GetComponent<AudioSource>().Play();
        defeated.GetComponent<SpriteRenderer>().sprite = defeatedSprite;*/
        //room.GetComponent<RoomController>().updateEnemyCount(-1);
        base.Die();
        OnDie?.Invoke();//Para llamar a la room
        if(dropPrefab != null) Instantiate(dropPrefab,transform.position,transform.rotation);
          
    }

    void SetupComponents(){
        //posible inicialización del [Required] BoxCollider2D y otros,
        //para no tener que ajustarlos luego de añadir el script,
    }

    void SetWaits(){
        waitMove = new WaitForSeconds(moveTime);
        waitAttack = new WaitForSeconds(attackTime);
        waitCoolDown = new WaitForSeconds(coolDownTime);
    }

    void SetTarget(Transform target){
        enemyMovement.SetTarget(target);
        enemyAttack.SetTarget(target);
    }

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
