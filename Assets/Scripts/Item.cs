using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int count;
    public enum RareGradation
    {
        usually,
        interesting,
        strange,
        rare,
        favnic,
        unique,
    }
    public Sprite sprite;
    public string name;
    public int id;
}
public class OrePiece : Item
{
    public int ReforgeHardness;
    public int PiecesForOneBar;
}
public class Potion : Item
{
    
}
public class Weapon : Item
{
    public int damage;
}
public class Armor : Item
{
    public int strength;
    public int health;
    public int armorPoints;
}

