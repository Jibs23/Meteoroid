using UnityEngine;
using System.Collections;

public class HealthUiScript : MonoBehaviour
{
    public SpriteRenderer PlayerSprite;
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;

    private void Start()
    {
        PlayerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        H1 = transform.GetChild(2).gameObject;
        H2 = transform.GetChild(1).gameObject;
        H3 = transform.GetChild(0).gameObject;
    }
    public void LoseH1()
    {
        H1.gameObject.SetActive(false);
        StartCoroutine(Flash());
    }
    public void LoseH2()
    {
        H2.gameObject.SetActive(false);
        StartCoroutine(Flash());
    }
    public void LoseH3()
    {
        H3.gameObject.SetActive(false);
        StartCoroutine(Flash());
    }
    private IEnumerator Flash() // Coroutine to flash the player sprite when hit
    {
        Color NormalColor;
        ColorUtility.TryParseHtmlString("#B0EA3F", out NormalColor);
        for (int i = 0; i < 3; i++) // Flash 3 times
        {
            PlayerSprite.color = Color.white;
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
            PlayerSprite.color = NormalColor;
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        }
    }
    
}
