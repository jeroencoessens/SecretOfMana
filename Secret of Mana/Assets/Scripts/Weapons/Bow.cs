using UnityEngine;
using System.Collections;

public class Bow : Weapon {

    // The bow is string long range weapon, useless at close range
    private int IncreaseAttack = 25;

    // Arrow
    private GameObject _arrowPrefab;
    private Transform _arrowsCirculating;

    public Bow()
    {
        Name = "Bow";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;

        _arrowPrefab = Resources.Load("Prefabs/Arrow") as GameObject;
        _arrowsCirculating = GameObject.Find("Arrows").transform;
    }

    public override void Behaviour(VisualCharacter character)
    {
        float speed = 45.0f;
        float dist;
        Vector3 pos = Vector3.zero;

        // Shooting plane
        Plane plane = new Plane(Vector3.up, new Vector3(0, 1.5f, 0));
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dist))
        {
            pos = ray.GetPoint(dist);
        }

        Vector3 shootDirection = pos - character.transform.position;

        // Spawn arrow
        var arrow = GameObject.Instantiate(_arrowPrefab, character.transform.position + (shootDirection.normalized * 2.0f), Quaternion.identity) as GameObject;
        arrow.transform.SetParent(_arrowsCirculating);

        // Fire arrow
        arrow.GetComponent<Rigidbody>().velocity = shootDirection * (speed / shootDirection.magnitude);
    }
}
