using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> stars;
    public GameObject starPrefab;
    public int currHealth;
    public int maxHealth;

    void Start() {
        stars = new List<GameObject>();
        setUp();
        // takeDamage(1);
    }

    void setUp() {
        for (int i = 0; i < currHealth; i++) {
            GameObject newStar = Instantiate(starPrefab, transform);
            stars.Add(newStar);
            Debug.Log(newStar.GetComponent<Image>().color);
        }
        Debug.Log("finished adding stars?");
        Debug.Log(stars.Count);
    }

    public void takeDamage(int damage) {
        Debug.Log(stars.Count);
        for (int i = currHealth-1; i > currHealth-1-damage; i--) {
            stars[i].GetComponent<Image>().color = new Color32(0,0,0,255);
            Debug.Log("setting new color");
        }
        currHealth -= damage;
    }
}
