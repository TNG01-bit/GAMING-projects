using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    private void Update()
    {
        InteractionRay();
    }
    void InteractionRa()
        {Ray ray = mainCam.ViewportPointToRay(Vector3.one/2f)
         RaycastHit hit = false;
        bool hitSomething = false;
        if(Physics.Raycast(ray, out hit, interactionDistance)) {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactionUI != null) {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
    }
}
