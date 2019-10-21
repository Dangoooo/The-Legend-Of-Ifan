using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class GenericDamage : MonoBehaviour
{
    public float damage;
    public  string otherTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == otherTag && collision.isTrigger)
        {
            GenericHealth temp = collision.gameObject.GetComponent<GenericHealth>();
            if(temp)
            {
                temp.Damage(damage);
            }
        }
    }
}
