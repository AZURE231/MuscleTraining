using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] TMP_Text muscleNumber;
    private void Start()
    {
        muscleNumber.text = FindObjectOfType<Combat>().playerAttack.ToString();
    }

    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
