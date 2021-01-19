using UnityEngine;

// This class contains general information describing an actor (player or enemies).
// It is mostly used for AI detection logic and determining if an actor is friend or foe
public class Actor : MonoBehaviour
{
    [Tooltip("Represents the affiliation (or team) of the actor. Actors of the same affiliation are friendly to eachother")]
    [SerializeField] private int _affiliation = 0;
    [Tooltip("Represents point where other actors will aim when they attack this actor")]
    [SerializeField] private Transform _aimPoint = null;

    private ActorsManager m_ActorsManager = null;
    
    public int affiliation { get => _affiliation; }
    public Transform aimPoint { get => _aimPoint; }

    private void Start()
    {
        m_ActorsManager = GameObject.FindObjectOfType<ActorsManager>();
        DebugUtility.HandleErrorIfNullFindObject<ActorsManager, Actor>(m_ActorsManager, this);

        // Register as an actor
        if (!m_ActorsManager.actors.Contains(this))
        {
            m_ActorsManager.actors.Add(this); 
        }
    }

    private void OnDestroy()
    {
        // Unregister as an actor
        if (m_ActorsManager)
        {
            m_ActorsManager.actors.Remove(this);
        }
    }
}
