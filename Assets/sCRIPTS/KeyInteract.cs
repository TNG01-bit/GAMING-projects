using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    [SerializeField] float openRange = 14f;
    bool granted = false;
    
    void Start()
    {
        
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.E) && !granted)
            {
                Vector3 player = PlayerMovement.instance.transform.position - gameObject.transform.position;
                float dist = player.magnitude;
                if (dist < openRange)
                {
                PlayerMovement.instance.PlayerKeys++;
                granted = true;
                }
            }
        

    }
}
