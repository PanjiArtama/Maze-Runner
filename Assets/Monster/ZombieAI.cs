using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public float chaseDistance = 10f; // Jarak di mana zombie mulai mengejar pemain
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Hitung jarak antara zombie dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika jarak kurang dari chaseDistance, zombie mengejar pemain
        if (distanceToPlayer < chaseDistance)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true); // Aktifkan animasi berjalan
        }
        else
        {
            animator.SetBool("IsWalking", false); // Nonaktifkan animasi berjalan
        }
    }
}
