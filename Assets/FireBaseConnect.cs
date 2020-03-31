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


    // database initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://new-project-1d112.firebaseio.com");

        // Get the root reference location of the database.
         reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
	

    public void SaveCharacter(Character character)
    {
       

        string json = JsonUtility.ToJson(character);
        // adding character to firebase database
            reference.Child("Characters").Child("Character" +characterCount).SetRawJsonValueAsync(json);

    }

public void GetCharactersFromDatabase()
    {
        characters.Clear();

        FirebaseDatabase.DefaultInstance.GetReference("Characters").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // checking for error
                Debug.Log("Database connection error, task is faulted");
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
            // debug to view all characters in the list
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
        foreach (var character in characters)
         {
             Debug.Log(string.Format("Characters \nCharacter: {0} \nIcon ID: {1} \nPlayer: {2} \nCharacter: {3}  \nHP: {4}  \nInitiative: {5} \nRace: {6} \nClass: {7}",
                 characters.IndexOf(character), 0, character.playerName, character.characterName, character.characterHP, character.characterInitiative, character.characterRace, character.characterClass));
            }

 

    }

   
   
    
}
