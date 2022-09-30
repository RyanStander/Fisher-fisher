using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] List<string> tutorials=null;
    [SerializeField] TextMeshProUGUI tutText=null;
    private int _tutorialIndex=0;
    private int _prevIndexVal = -1;

    [SerializeField] GameObject _enemy=null;
    [SerializeField] GameObject _boatCounter = null;
    private bool _enemySpawned = false;

    private float _waitTime = 7f;
    private float _spawnDelay = 7f;

    [SerializeField] string completionScene = "Start Scene";

    private bool _hitPlunger = false;
    private bool _skillCheckStart = false;
    private bool _skillCheckCompleted = false;

    [SerializeField] Camera DisplayCamera=null;
    [SerializeField] Transform[] CameraPoints=null;
    [SerializeField] GameObject _displayPanel = null;

    [SerializeField] AudioSource audioSource=null;
    [SerializeField] AudioClip[] randomSounds = null;
    [SerializeField] AudioClip plungerSound = null;

    private bool _plungerFound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Debug.Log("Index size: " + tutorials.Length + " CurrentIndex: " + _tutorialIndex);
        TutorialCompleted();
        CurrentTutorial();
        if (_tutorialIndex == 7&& _plungerFound==false)
        {
            _plungerFound = true ;
            audioSource.PlayOneShot(plungerSound);
            _prevIndexVal = _tutorialIndex;
        }
        else if (_tutorialIndex != _prevIndexVal )
        {
            _prevIndexVal = _tutorialIndex;
            audioSource.PlayOneShot(randomSounds[Random.Range(0, randomSounds.Length)]);
        }
    }

    private void TutorialCompleted()
    {
        //when the index has reached the end it changed back to the main menu
        if (tutorials.Count == _tutorialIndex)
        {
            SceneManager.LoadScene(completionScene);

        }
    }
    public void CurrentTutorial()
    {
        //used to keep track of what the current part of the tutorial is
            tutText.SetText(tutorials[_tutorialIndex]);
        switch (_tutorialIndex)
        {
            case 0://Arrr there matey you ready to save us some fish!
                NextTutTimer();
                break;
            case 1://Lets try moving the ship forward.
                if (Input.GetAxis("Vertical")>0)
                {
                    _tutorialIndex++;
                }
                break;
            case 2://Arrr that's the stuff! Now let us go backwards.
                if (Input.GetAxis("Vertical") < 0)
                {
                    _tutorialIndex++;
                }
                break;
            case 3://Now for steering! Whilst sailing forwards or backwards try turning left or right.
                if ((Input.GetAxis("Horizontal") < 0|| Input.GetAxis("Horizontal") > 0)&&(Input.GetAxis("Vertical") > 0|| Input.GetAxis("Vertical") < 0))
                {
                    _tutorialIndex++;
                }
                break;
            case 4://Now with the movement out of our way let us get to saving the oceans matey!
                NextTutTimer();
                break;
            case 5://Look at all the jumping fish, enemies will hunt for these spots!
                SetCameraPosition(0);
                _displayPanel.SetActive(true);
                NextTutTimer();
                break;
            case 6://Arr look at that pesky little boat! Stop it from fishing the ocean dry!
                if (_spawnDelay <= 0)
                {
                    SetCameraPosition(1);
                    _tutorialIndex++;
                }
                else
                {
                    _spawnDelay -= Time.deltaTime;
                }
                if (!_enemySpawned)
                {
                    _enemy = Instantiate(_enemy, Vector3.zero, Quaternion.Euler(0, 180, 0));
                    _enemySpawned = true;
                    _boatCounter.SetActive(true);
                    SetCameraPosition(1);
                }
                break;
            case 7://Hold the left mouse button to aim at the target, when ready, let go to fire the harpoon!
                _displayPanel.SetActive(false);
                if (_hitPlunger)
                {
                    _tutorialIndex++;
                }
                break;
            case 8://That's a great shot laddie. Now drag ‘em to port.
                if (_skillCheckStart)
                {
                    _tutorialIndex++;
                }
                break;
            case 9://Make sure they don’t come loose by pressing Spacebar when the plunger is in the colored area
                if (_skillCheckCompleted)
                {
                    _tutorialIndex++;
                }
                break;
            case 10://Arr matey you did great. I think you can do it on your own now! TED needs a break.
                if (_enemy == null)
                {
                    _tutorialIndex++;
                }
                break;
            case 11://EXIT APLICATION YOU SLACKJAW
                break;
        }
    }
    public void NextTutTimer()
    {
        //this is to make it so that the next part of the tutorial wont instantly be skipped
        if (_waitTime <= 0)
        {
            _tutorialIndex++;
            _waitTime = 7;
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }
    public void PlungerHit(float speed, float treshold, int eventChance, bool plungerStrength)
    {
        if (_tutorialIndex == 7) 
        {
            _hitPlunger = true;
        }
    }
    public void SkillCheckStart()
    {
        if (_tutorialIndex == 8)
        {
            _skillCheckStart = true;
            //tutText.SetText("Make sure they don’t come loose by pressing Spacebar when the plunger is in the colored area!");
        }
    }
    public void SkillCheckSucceed()
    {
        if (_tutorialIndex == 9)
        {
            _skillCheckCompleted = true;
            //tutText.SetText("Arr matey you did great. I think you can do it on your own now! TED needs a break.");
        }
    }
    void OnEnable()
    {
        EventManager.onStartSkillCheckEvent += PlungerHit;
        EventManager.onTutorialSkillCheckStart += SkillCheckStart;
        EventManager.onSuccessfulSkillCheck += SkillCheckSucceed;
    }
    void OnDisable()
    {
        EventManager.onStartSkillCheckEvent -= PlungerHit;
        EventManager.onTutorialSkillCheckStart -= SkillCheckStart;
        EventManager.onSuccessfulSkillCheck -= SkillCheckSucceed;
    }
    void SetCameraPosition(int num)
    {
        DisplayCamera.transform.position = CameraPoints[num].position;
        DisplayCamera.transform.rotation = CameraPoints[num].rotation;
    }
    
}
