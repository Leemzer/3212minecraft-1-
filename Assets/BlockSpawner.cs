using UnityEngine;
using UnityEngine.Events;

public class BlockSpawner : MonoBehaviour
{
    public float rayDistance = 10f;

    public GameObject blockPrefab;
    public GameObject blockPrefab1;
    public GameObject blockPrefab2;
    public GameObject blockPrefab3;

    public KeyCode destroyBlock;
    public KeyCode spawnBlock;

    public KeyCode selectBlock0;
    public KeyCode selectBlock1;
    public KeyCode selectBlock2;
    public KeyCode selectBlock3;

    public UnityEvent onBlockSpawn;
    public UnityEvent onBlockDestroy;

    public UnityEvent onSelectBlock0;
    public UnityEvent onSelectBlock1;
    public UnityEvent onSelectBlock2;
    public UnityEvent onSelectBlock3;

    private GameObject currentBlockPrefab;

    void Start()
    {
        currentBlockPrefab = blockPrefab;
    }

    void Update()
    {
        ReadInput_Update();
    }

     void ReadInput_Update()
    {
        if (Input.GetKeyDown(spawnBlock)) onBlockSpawn.Invoke();
        if (Input.GetKeyDown(destroyBlock)) onBlockDestroy.Invoke();

        if (Input.GetKeyDown(selectBlock0))currentBlockPrefab = blockPrefab;
        if (Input.GetKeyDown(selectBlock1))currentBlockPrefab = blockPrefab1; 
        if (Input.GetKeyDown(selectBlock2))currentBlockPrefab = blockPrefab2; 
        if (Input.GetKeyDown(selectBlock3))currentBlockPrefab = blockPrefab3; 
    }



    public void SelectBlock0() => currentBlockPrefab = blockPrefab;
    public void SelectBlock1() => currentBlockPrefab = blockPrefab1;
    public void SelectBlock2() => currentBlockPrefab = blockPrefab2;
    public void SelectBlock3() => currentBlockPrefab = blockPrefab3;

    public void DestroyBlock()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("Block"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void SpawnBlock()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("Block") && currentBlockPrefab != null)
            {
                Vector3 spawnPosition = hit.collider.transform.position + hit.normal;
                Instantiate(currentBlockPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
