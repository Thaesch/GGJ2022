using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{

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
        navMeshAgent.SetDestination(fountainOfLife.transform.position);
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

    private void Die(DeathAnimations animation)
    {
        Destroy(gameObject);
        Debug.Log("Dead");
        //todo: Play Animation based on caller
    }
}
