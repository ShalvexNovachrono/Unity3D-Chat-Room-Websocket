using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
  public Transform NextPage;
  public Transform WebSocketWorker;
  public InputField usernameInput;
  public Button LoginButton;

  private void Start()
  {
    // ISSUE: method pointer
    this.LoginButton.onClick.AddListener(new UnityAction((object) this, __methodptr(Login_Function)));
  }

  private void Login_Function()
  {
    this.WebSocketWorker.gameObject.SetActive(true);
    Object.FindObjectOfType<global::WebSocketWorker>().Username = this.usernameInput.text;
    this.NextPage.gameObject.SetActive(true);
    this.transform.gameObject.SetActive(false);
  }

  public Login()
  {
    base.\u002Ector();
  }
}
