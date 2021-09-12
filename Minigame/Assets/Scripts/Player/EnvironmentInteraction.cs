using UnityEngine;

public class EnvironmentInteraction : MonoBehaviour
{
    public Renderer dissolve;
    private string colorProperty;
    private Color edgeColor;

    void Start()
    {
        colorProperty = dissolve.sharedMaterial.shader.GetPropertyName(0);
        dissolve.sharedMaterial.SetColor(colorProperty, Color.white);
        edgeColor = dissolve.sharedMaterial.GetColor(colorProperty);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case Names.GreenVolume:
                dissolve.sharedMaterial.SetColor(colorProperty, Color.green);
                break;
            case Names.RedVolume:
                dissolve.sharedMaterial.SetColor(colorProperty, Color.red);
                break;
            case Names.BlueVolume:
                dissolve.sharedMaterial.SetColor(colorProperty, Color.blue);
                break;
            case Names.OrangeVolume:
                dissolve.sharedMaterial.SetColor(colorProperty, Color.yellow);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dissolve.sharedMaterial.SetColor(colorProperty, edgeColor);
    }
}
