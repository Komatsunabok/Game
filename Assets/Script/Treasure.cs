using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject effectPrefab; // �G�t�F�N�g�̃v���n�u

    void Start()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;  // �󕨂�Collider�̓g���K�[
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
