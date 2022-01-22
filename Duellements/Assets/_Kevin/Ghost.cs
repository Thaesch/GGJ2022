using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using Photon.Pun;

[RequireComponent(typeof(Damagable))]
public class Ghost : MonoBehaviourPunCallbacks
{
    public HealthBar healthbar;
    private float health;

    Element element = Element.NORMAL;
    private enum DeathAnimations {FountainReached, Killed};

    public Renderer elementsRenderer;

    [SerializeField]
    private static readonly string[] elements = { "water", "fire", "earth", "air" };

    [SerializeField]
    private int minLives = 10;

    [SerializeField]
    private int maxLives = 100;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private Dictionary<string, int> assignedElements = new Dictionary<string, int>();


    public int MaxLives
    {
        get { return maxLives; }
    }

    public float Health
    {
        get { return health; }
    }

    private void Start()
    {
        if(PhotonNetwork.IsConnected && !photonView.IsMine) { enabled = false; navMeshAgent.enabled = false; return; }
        // TODO: Set Reference after instantiating
        navMeshAgent.SetDestination(Vector3.zero);
        healthbar.setMaxHealth(maxLives);
        health = maxLives;

        int rand =  GetRandomElements()[0];
        Debug.Log(rand);

        this.element = Elements.fromNumber(rand+1);
        elementsRenderer.material.color = Elements.GetColorOf(element);
    }

    private void OnEnable()
    {
        GetComponent<Damagable>().OnDamaged += ReceiveDamage;
    }

    private void OnDisable()
    {
        GetComponent<Damagable>().OnDamaged -= ReceiveDamage;
    }



    public void Init(int difficulty)
    {
        switch (difficulty)
        {
            case 0: { ToEasyGhost(); break; }
            case 1: { ToMediumGhost(); break; }
            default: { ToHardGhost(); break; }
        }
    }

    private void ToEasyGhost()
    {
        AssignElements(1);
    }

    private void ToMediumGhost()
    {
        AssignElements(2);
    }

    private void ToHardGhost()
    {
        AssignElements(3);
    }
    
    private void AssignElements(int amount)
    {

        List<int> randomElements = GetRandomElements();

        for(int i=0; i<amount; i++)
        {
            int lives = Random.Range(minLives, maxLives);
            assignedElements.Add(elements[randomElements[i]], lives);

            element =  Elements.fromNumber(randomElements[i]);
        }

        // Todo: Update Grafik / ParticleEffect depending on the assigned elements
        // Todo: Hier kommt noch a Fehlersche (das zweimal dasselbe Element hinzugefügt wurde)

    }

   

    private List<int> GetRandomElements()
    {

        List<int> positions = new List<int>() { 0,1,2,3 };

        System.Random rnd = new System.Random();
        positions = positions.OrderBy(item => rnd.Next()).ToList<int>();
        return positions;

    }


    private void Die()
    {
        NetworkSpawner.Destroy(gameObject);
    }

    private void ReceiveDamage(float damage, Element incoming)
    {

        Relation rel = Elements.RelationOf(incoming, element);

        if (rel == Relation.Advantage) damage *= 4;
        else if (rel == Relation.Disadvantage) damage *= 0.25f;

        health -= damage;
        healthbar.setHealth(health);

        if (health <= 0)
        {
            Die();
        }

    }

    public void Released()
    {
        NetworkSpawner.Destroy(gameObject);
    }
}
