using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> stars = new List<GameObject>();
    public GameObject starPrefab;
    public Sprite test;
    public int currHealth;
    // public int maxHealth;

    void Start() {
    }

    public void setUp() {
        Debug.Log("Setting up health");
        Debug.Log(currHealth);
        foreach (GameObject star in stars) {
            Destroy(star);
        }
        stars = new List<GameObject>();
        for (int i = 0; i < currHealth; i++) {
            GameObject newStar = Instantiate(starPrefab, transform);
            stars.Add(newStar);
        }
        Debug.Log(stars.Count);

        // Sets the actual health of the player after generating containers
        for (int i = currHealth - 1; i > currHealth-1-(currHealth-health.hp); i--)
        {
            stars[i].GetComponent<Image>().sprite = test;
        }
        currHealth = health.hp;
    }

    public void takeDamage(int damage) {
        Debug.Log("Taking damage");
        Debug.Log(damage);
        Debug.Log(currHealth);
        Debug.Log(stars.Count);
        for (int i = currHealth-1; i > currHealth-1-damage; i--) {
            // stars[i].GetComponent<Image>().color = new Color32(0,0,0,255);
            stars[i].GetComponent<Image>().sprite = test;
            // Debug.Log("setting new color");
        }
        currHealth -= damage;
    }
}
