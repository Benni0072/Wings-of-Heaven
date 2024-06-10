using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class collectible : MonoBehaviour
{
    public UnityEvent OnCollected;
    private MeshRenderer renderer;

    public Animator Animator;
    public TriggerEventUnit collect;

    public Material NormalMaterial;
    public Material HighlightMaterial;



    //_____________________________________________

    void OnTriggerEnter(Collider other)
    {
    

    }
    public void Collect()
    {
        OnCollected.Invoke();

        Animator.SetTrigger("collect");

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
