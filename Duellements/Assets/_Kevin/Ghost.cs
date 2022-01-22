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
    private int currentHealth;

    private enum DeathAnimations {FountainReached, Killed};

    [SerializeField]
    private static readonly string[] elements = { "water", "fire", "earth", "air" };

    [SerializeField]
    private int minLives = 3;

    [SerializeField]
    private int maxLives = 5;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private GameObject fountainOfLife;

    private Dictionary<string, int> assignedElements = new Dictionary<string, int>();



    private void Start()
    {
        if(PhotonNetwork.IsConnected && !photonView.IsMine) { enabled = false; navMeshAgent.enabled = false; return; }
        // TODO: Set Reference after instantiating
        navMeshAgent.SetDestination(GameObject.Find("FountainOfLife").transform.position);
        healthbar.setMaxHealth(maxLives);
        currentHealth = maxLives;
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

    private void OnTriggerEnter(Collider other)
    {
        if (CollidedWithFountain(other))
        {
            Die(DeathAnimations.FountainReached);
        }
    }

    private bool CollidedWithFountain(Collider other)
    {
        return other.gameObject.GetComponent<FountainOfLife>() != null;
    }

    private void ReceiveDamage(float damange, Element element)
    {

        currentHealth = currentHealth - 1;
        healthbar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die(DeathAnimations.FountainReached);
        }

    }

    private void Die(DeathAnimations animation)
    {
        NetworkSpawner.Destroy(gameObject);
        Debug.Log("Dead");
        //todo: Play Animation based on caller
    }
}
