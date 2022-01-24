using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using Photon.Pun;
using UnityEngine.Serialization;

[RequireComponent(typeof(Damagable))]
public class Ghost : MonoBehaviourPunCallbacks
{
    public HealthBar healthbar;
    private float health;

    [SerializeField] Element element = Element.NORMAL;
    private enum DeathAnimations {FountainReached, Killed};

    public Renderer ghostRenderer;
    public ParticleSystemRenderer ghostTail;

    [SerializeField]
    private static readonly string[] elements = { "water", "fire", "earth", "air" };

    [SerializeField]
    private int minLives = 10;

    [SerializeField]
    private int maxLives = 100;

    private Dictionary<string, int> assignedElements = new Dictionary<string, int>();

    public int MaxLives
    {
        get { return maxLives; }
        set {  maxLives = value; }
    }

    public float Health
    {
        get { return health; }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
            stream.SendNext(maxLives);
        }
        else
        {
            health = (float)stream.ReceiveNext();
            maxLives = (int)stream.ReceiveNext();
            healthbar.setMaxHealth(maxLives);
            healthbar.setHealth(health); 
        }
    }

    private void Start()
    {
        if (!(PhotonNetwork.IsConnected && !photonView.IsMine))
        {
            health = maxLives;
            healthbar.setMaxHealth(maxLives);

            this.element = Elements.GetRandomElement();
            ghostRenderer.material.SetColor("_OutlineColor", Elements.GetOutlineColorOf(element));
            ghostRenderer.material.SetColor("_MainColor", Elements.GetColorOf(element));
            Color elementColor = Elements.GetOutlineColorOf(element);
            elementColor.a = .5f;
            ghostTail.material.color = elementColor;
        }
        // TODO: Set Reference after instantiating
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

            element =  Elements.GetRandomElement();
        }

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
        if (photonView.IsMine)
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
        if (photonView.IsMine)
            NetworkSpawner.Destroy(gameObject);
    }
}
