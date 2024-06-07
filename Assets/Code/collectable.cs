using UnityEngine;
using UnityEngine.Events;

public class collectible : MonoBehaviour
{
    public UnityEvent OnCollected;
    private MeshRenderer renderer;

    public Material NormalMaterial;
    public Material HighlightMaterial;
    //_____________________________________________

    public void Collect()
    {
        OnCollected.Invoke();
        Destroy(gameObject);
    }

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void Highlight()
    {
        renderer.material = HighlightMaterial;
    }

    public void Unhighlight()
    {
        renderer.material = NormalMaterial;
    }

}
