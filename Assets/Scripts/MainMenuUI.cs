using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Menu Panels")]
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject optionsMenu;

    [Header("Buttons")]
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;

    public List<Button> gameButtons;

    public List<Button> returnButtons;

    private int sceneNumber = 0;

    /*[SerializeField]
    Color highlightedByEmission = new(3.355232f, 5.190451f, 1.787278f, 2.792784f);
    public List<Button> highlightedButtons;

    private XRBaseInteractable interactable;

    private Image imageComp;
    private Color emissionColor;*/

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(EnableStartMenu);
        optionsButton.onClick.AddListener(EnableOptions);
        quitButton.onClick.AddListener(QuitApp);

        //int i = 0;
        foreach (var item in gameButtons)
        {
            //i++;
            item.onClick.AddListener(() => LoadGame(sceneNumber));
        }

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }

        /*if (!highlightedButtons.Equals(null))
        {
            imageComp = highlightedButtons[0].GetComponent<Image>();
            emissionColor = imageComp.material.GetColor("_EmissionColor");
        }*/
    }

    public void LoadGame(int sceneNumber)
    {
        HideAllPanels();
        SceneManager.LoadScene(sceneNumber);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void EnableStartMenu()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void EnableOptions()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void HideAllPanels()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void SetSceneNumber(int sceneNumber)
    {
        this.sceneNumber = sceneNumber;
    }
}

/*[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class MainMenuUI : MonoBehaviour
{
    public MyIntEvent m_MyEvent;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new MyIntEvent();

        m_MyEvent.AddListener(Ping);
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke(5);
        }
    }

    void Ping(int i)
    {
        Debug.Log("Ping" + i);
    }
}
*/

