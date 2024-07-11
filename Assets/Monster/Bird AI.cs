using UnityEngine;
using UnityEngine.AI;

public class BirdAI : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float chaseDistance = 10f; // Jarak di mana burung mulai mengejar pemain
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Hitung jarak antara burung dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika jarak kurang dari chaseDistance, burung mengejar pemain
        if (distanceToPlayer < chaseDistance)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Eagle_Fly", true); // Aktifkan animasi kepakan sayap
        }
        else
        {
            agent.SetDestination(transform.position); // Berhenti jika jarak terlalu jauh
            animator.SetBool("Eagle_Fly", false); // Nonaktifkan animasi kepakan sayap
        }
    }
}
