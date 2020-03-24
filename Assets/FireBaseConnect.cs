using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBaseConnect : MonoBehaviour {
    DatabaseReference reference;
    public Text text;
    public InputField inputField;
    List<Character> characters = new List<Character>();
    public bool taskComplete = false;
    public long characterCount;
    [SerializeField]  CharacterTemplateLoad characterTemplateLoad;


    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://new-project-1d112.firebaseio.com");

        // Get the root reference location of the database.
         reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
	
	// Update is called once per frame
	void Update () {
        
    }


    public void SaveCharacter(Character character)
    {
       

        string json = JsonUtility.ToJson(character);
       // for (int i=21; i < 31; i++)
        //{
            reference.Child("Characters").Child("Character" +characterCount).SetRawJsonValueAsync(json);
       // }
      //  reference.Child("Characters").Child("Character1").SetRawJsonValueAsync(json);
    }

public void GetCharactersFromDatabase()
    {
        characters.Clear();

        FirebaseDatabase.DefaultInstance.GetReference("Characters").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
               DataSnapshot snapshotCount = task.Result;
                characterCount = snapshotCount.ChildrenCount;
              foreach (var child in snapshotCount.Children)
                {
                    Character character = JsonUtility.FromJson<Character>(child.GetRawJsonValue());
                    characters.Add(character);
                }
               
                
            }
            Debug.Log("Character count in the database " + characterCount);
            GetAllCharacters();
            characterTemplateLoad.connectComplete = true;

        });

    }

  public List<Character> CharacterList()
    {
        return characters;
    }
    
    public void GetAllCharacters()
    {
        
        Debug.Log(characters.Count);
        foreach (var character in characters)
         {
             Debug.Log(string.Format("Characters \nCharacter: {0} \nIcon ID: {1} \nPlayer: {2} \nCharacter: {3}  \nHP: {4}  \nInitiative: {5} \nRace: {6} \nClass: {7}",
                 characters.IndexOf(character), 0, character.playerName, character.characterName, character.characterHP, character.characterInitiative, character.characterRace, character.characterClass));
            }

 

    }

   
   
    
}
