using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Kecepatan gerak kamer
    public float xPosMaximum;
    public float yPosMaximum;

    [Header("Detection Settings")]
    public float xLength; // Lebar area deteksi di sumbu X
    public float yLength; // Tinggi area deteksi di sumbu Y
    public LayerMask detectionLayer; // Lapisan untuk objek yang akan dideteksi




    void Start()
    {
    }

    void Update()
    {
        if (GameManager.Instance.isPause) return;

        HandleMovement();

        if(Input.GetMouseButtonDown(0))
            CheckAreaAroundTarget();
    }

    // Fungsi untuk menggerakkan kamera dengan menggunakan input
    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Input kanan/kiri (A/D atau panah kanan/kiri)
        float vertical = Input.GetAxis("Vertical");     // Input atas/bawah (W/S atau panah atas/bawah)

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        newPosition.x = Mathf.Clamp(newPosition.x, -xPosMaximum, xPosMaximum);
        newPosition.y = Mathf.Clamp(newPosition.y, -yPosMaximum, yPosMaximum);

        transform.position = newPosition;
    }

    // Fungsi untuk mendeteksi objek saat klik kiri
    void CheckAreaAroundTarget()
    {
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.zero;
        Vector2 boxSize = new Vector2(xLength, yLength);
        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, direction, 0f, detectionLayer);

        // Cek apakah ada objek yang terdeteksi dalam area
        if (hit.collider != null)
        {
            MemoryObject obj = hit.collider.GetComponent<MemoryObject>();
            if (obj != null)
            {
                MemoryManager mm = GameManager.Instance.memoryManager;

                if(!mm.GetItemIsUnlock(obj.index))
                {
                    mm.UnlockItem(obj.index);
                }
            }
        }
        else
        {
            Debug.Log("Tidak ada objek terdeteksi di area sekitar target.");
        }
    }

    // Visualisasi area deteksi dalam editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 boxSize = new Vector3(xLength, yLength, 0);
        Gizmos.DrawWireCube(transform.position, boxSize);
        
    }
}
