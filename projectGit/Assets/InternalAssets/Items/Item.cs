using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isWeapon;
    public GameObject droppedModel;
    public GameObject equippedModel;
    public GameObject PrimaryActionObject;
    public int life = 0;
    public int maxLife = 0;


    GameObject EquippedItem;
    private void Start() {
        droppedModel.SetActive(true);
        equippedModel.SetActive(false);
        if (PrimaryActionObject != null) {
            PrimaryActionObject.SetActive(false);
        }
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        Rigidbody2D rigidB = gameObject.AddComponent<Rigidbody2D>();
        collider.isTrigger = true;
        rigidB.isKinematic = true;
    }
    public void equip(GameObject parent) {
        GameObject item = Instantiate(equippedModel);
        item.transform.position = parent.transform.position;
        item.transform.rotation = parent.transform.rotation;
        item.transform.SetParent(parent.transform);
        item.SetActive(true);
        EquippedItem = item;
        
    }
    public void Unequip() {
        Destroy(EquippedItem);
    }
    public void PrimaryAction(Transform origin) {
        var bullet = Instantiate(PrimaryActionObject, origin.position, origin.localRotation);
        bullet.GetComponent<Bullet>().Shoot();
    }
}
