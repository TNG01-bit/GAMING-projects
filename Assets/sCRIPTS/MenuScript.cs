using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI m_KeyText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_KeyText.text = "Key Number : " + PlayerMovement.instance.PlayerKeys;
    }
}
