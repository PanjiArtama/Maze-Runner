// using UnityEngine;
// using UnityEngine.AI;

// public class MonsterController : MonoBehaviour
// {
//     public float speed = 1.0f; // Kecepatan gerakan monster
//     public float avoidStrength = 2.0f; // Kekuatan penghindaran
//     public float avoidDistance = 1.5f; // Jarak penghindaran
//     public float gameOverDistance = 5.0f; // Jarak minimum untuk game over

//     public LayerMask wallLayer; // Layer untuk mendeteksi tembok

//     private Transform player; // Transform pemain
//     private float initialY; // Posisi y awal dari monster
//     private Rigidbody rb; // Rigidbody dari monster
//     private Animator animator; // Animator dari monster

//     private void Start()
//     {
//         // Temukan objek pemain dengan tag "Player"
//         player = GameObject.FindWithTag("Player").transform;
//         // Simpan posisi y awal dari monster
//         initialY = transform.position.y;
//         // Dapatkan Rigidbody dan Animator dari monster
//         rb = GetComponent<Rigidbody>();
//         animator = GetComponent<Animator>();
//     }

//     private void Update()
//     {
//         // Hitung jarak antara player dan monster
//         float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//         // Periksa apakah jarak lebih kecil dari jarak game over
//         if (distanceToPlayer < gameOverDistance)
//         {
//             // Panggil fungsi game over atau tindakan yang sesuai
//             GameOver();
//         }

//         // Hitung arah menuju pemain, hanya pada sumbu x dan z
//         Vector3 directionToPlayer = new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z);

//         // Hitung gaya penghindaran dari tembok menggunakan Raycast
//         Vector3 avoidanceForce = Vector3.zero;
//         Vector3[] rayDirections = { transform.forward, -transform.forward, transform.right, -transform.right };
//         foreach (var direction in rayDirections)
//         {
//             Ray ray = new Ray(transform.position, direction);
//             RaycastHit hit;
//             if (Physics.Raycast(ray, out hit, avoidDistance, wallLayer))
//             {
//                 // Tentukan titik di mana monster harus menghindari tembok
//                 Vector3 avoidPoint = hit.point + hit.normal * 0.5f; // Misalnya, menghindari dengan jarak 0.5 unit dari tembok

//                 // Hitung arah menghindari
//                 Vector3 avoidDirection = transform.position - avoidPoint;
//                 avoidanceForce += avoidDirection.normalized * avoidStrength;

//                 // Debug
//                 Debug.DrawLine(ray.origin, hit.point, Color.red);
//             }
//             else
//             {
//                 Debug.DrawLine(ray.origin, ray.origin + direction * avoidDistance, Color.green);
//             }
//         }

//         // Gabungkan arah menuju pemain dan gaya penghindaran
//         Vector3 finalDirection = directionToPlayer + avoidanceForce;

//         // Gerakkan monster menggunakan Rigidbody, hanya pada sumbu x dan z
//         Vector3 move = finalDirection.normalized * speed;
//         move.y = 0; // Tetap di posisi y awal

//         rb.velocity = move;

//         // Pastikan posisi y tetap konstan
//         Vector3 position = rb.position;
//         position.y = initialY;
//         rb.position = position;

//         // Atur rotasi monster agar selalu menghadap ke pemain
//         if (directionToPlayer != Vector3.zero)
//         {
//             Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
//             rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * speed);
//         }

//         // Atur parameter animasi berdasarkan kecepatan
//         animator.SetFloat("Speed", move.magnitude);
//     }

//     private void GameOver()
//     {
//         // Lakukan tindakan game over di sini, misalnya:
//         Debug.Log("Game Over! Player terlalu dekat dengan monster.");
//         // Tambahan logika untuk restart game, menampilkan UI game over, dll.
//     }
// }
