using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame updat
    GameObject itemsGameObject;
    GameObject weaponsGameObject;
    public Collider2D nearItem;
    public GameObject objective;
    public float speed = 50;
    Inventory itemInventory;
    Stats stats;
    Slots slots = new Slots(0);
    Item primaryWeapon;
    private void Awake() {
        GetComponent<Move>().SetSpeed(speed);
    }
    void Start()
    {
        stats = GetComponent<Stats>();
        setStockSystems();
        
    }

    void Update()
    {
        // Debug.Log(itemInventory.index);
        if (Input.GetKeyDown(KeyCode.E) && nearItem) {
            Debug.Log(slots.SlotEquipable);
            GameObject parent;
            Item near = nearItem.GetComponent<Item>();
            if (near.isWeapon) {
                itemInventory.SetSlot(slots.SlotWeapon1);
                parent = weaponsGameObject;
            } else {
                itemInventory.SetSlot(slots.SlotItem);
                parent = itemsGameObject;
            }
            Debug.Log("is weapon:" + near.isWeapon);
            Debug.Log("Selected slot:" + itemInventory.index);
            GameObject obj = itemInventory.pick(nearItem);
            Item item = obj.GetComponent<Item>();
            item.equip(parent);
            if (item.isWeapon) {
                primaryWeapon = item;
            }
            // item.equipedModel.SetActive(true);

            // Instantiate(obj, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            primaryWeapon.PrimaryAction((weaponsGameObject.transform));
        }
    }

    private void FixedUpdate() {
        float lookY = Input.mousePosition.y;
        float lookX = Input.mousePosition.x;
        objective.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
            lookX,
            lookY,
            -Camera.main.transform.position.z
        ));
        Vector3 vecToTarget = objective.transform.position -transform.position;
        float angle = Mathf.Atan2(vecToTarget.y,vecToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponsGameObject.transform.rotation = Quaternion.Slerp(weaponsGameObject.transform.rotation, q, Time.deltaTime * 10);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        Item item;
        bool isItemType = other.TryGetComponent<Item>(out item);
        if (isItemType) {
            nearItem = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Item item;
        bool isItemType = other.TryGetComponent<Item>(out item);
        if (isItemType) {
            nearItem = null;
        }
    }

    void setStockSystems() {
        
        itemsGameObject = new GameObject("items");
        weaponsGameObject = new GameObject("weapons");
        setParent(itemsGameObject, gameObject);
        setParent(weaponsGameObject, gameObject);
        
        // inventory = GetComponent<Inventory>();
        itemInventory = gameObject.AddComponent<Inventory>();
        itemInventory.stats = stats;
        
    }
    void setParent(GameObject child, GameObject parent) {
        child.transform.SetParent(parent.transform);
        child.transform.position = parent.transform.position;
    }
}

struct Slots{
    public int SlotWeapon1;
    public int SlotWeapon2;
    public int SlotItem;
    public int SlotEquipable;
    public Slots(int zero) {
        this.SlotWeapon1 = zero;
        this.SlotWeapon2 = 1;
        this.SlotItem = 2;
        this.SlotEquipable = 3;
    }
}