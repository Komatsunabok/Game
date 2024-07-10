using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject effectPrefab; // エフェクトのプレハブ

    void Start()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;  // 宝物のColliderはトリガー
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Treasure found!");
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
