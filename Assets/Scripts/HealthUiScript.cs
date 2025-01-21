using UnityEngine;

public class HealthUiScript : MonoBehaviour
{
    private GameObject H1;
    private GameObject H2;
    private GameObject H3;

    private void Start()
    {
        H1 = transform.GetChild(2).gameObject;
        H2 = transform.GetChild(1).gameObject;
        H3 = transform.GetChild(0).gameObject;
    }
    public void LoseH1()
    {
        H1.gameObject.SetActive(false);
    }
    public void LoseH2()
    {
        H2.gameObject.SetActive(false);
    }
    public void LoseH3()
    {
        H3.gameObject.SetActive(false);
    }
    
}
