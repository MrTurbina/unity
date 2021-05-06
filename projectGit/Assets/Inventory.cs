using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int index = 0; 
    public int size = 3;
    GameObject[] items;
    GameObject pocket;
    public Stats stats;
    
    public int SetSlot(int position) {
        index = position;
        /* if (position < size -1 && position >= 0 ) {
        } */
        return index;
    }
    public GameObject pick(Collider2D collider) {
        Debug.Log("CURRENT INDEX: " +index);
        if (items[index] != null) {
            drop();
        }
        
        GameObject obj = collider.gameObject;
        items[index] = obj;

        obj.transform.SetParent(pocket.transform);
        checkItem(obj, true);
        return obj;
    }
    public void drop() {
        GameObject item = items[index];
        item.GetComponent<Item>().Unequip();
        item.transform.SetParent(null);
        item.transform.position = gameObject.transform.position;
        checkItem(item, false);
        // items[index]
        
        items[index] = null;
    }
    private void Start() {
        items = new GameObject[size];
        pocket = new GameObject("pocket");
        pocket.transform.SetParent(gameObject.transform);
        pocket.SetActive(false);
    }
    private void checkItem(GameObject item, bool add) {
        Item itemComponent = item.GetComponent<Item>();
        if (add) {
            stats.life += itemComponent.life;
            stats.maxLife += itemComponent.maxLife;
        } else {
            stats.life -= itemComponent.life;
            stats.maxLife -= itemComponent.maxLife;
        }
    }
    private void Update() {
        
    }
}
