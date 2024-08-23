using UnityEngine;
using TMPro;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] TMP_Text muscleNumber;
    private void Start()
    {
        muscleNumber.text = FindObjectOfType<Combat>().enemyAttack.ToString();
    }

    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
