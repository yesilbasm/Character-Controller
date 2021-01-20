using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    private List<Character> characters = new List<Character>();
    public List<Character> Characters { get { return characters; } set { characters = value; } }

    private Character player;
    public Character Player
    {
        get
        {
            if (player == null)
            {
                foreach (var character in Characters)
                {
                    if (character.CharacterType == CharacterType.Player)
                        player = character;
                }
            }
            return player;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddCharacter(Character character)
    {
        if (!Characters.Contains(character))
        {
            Characters.Add(character);
        }
    }

    public void RemoveCharacter(Character character)
    {
        if (Characters.Contains(character))
        {
            Characters.Remove(character);
        }
    }


    public Character GetClosestAI(Vector3 sourcePosition)
    {
        float minDistance = Mathf.Infinity;
        Character character = null;

        foreach (var c in Characters)
        {
            if (c.CharacterType == CharacterType.Player)
                continue;

            float distance = Vector3.Distance(sourcePosition, c.transform.position);
            if (distance < minDistance)
                character = c;
        }

        return character;
    }


}