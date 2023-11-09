// Decompiled with JetBrains decompiler
// Type: WebSocketWorker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B34C14AB-0760-406D-ABE6-62CD929EE8CE
// Assembly location: D:\Download\folder\Chat Room_Data\Managed\Assembly-CSharp.dll
// Compiler-generated code is shown

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WebSocketSharp;

public class WebSocketWorker : MonoBehaviour
{
  private WebSocket ws;
  public Button ReConnectButton;
  public Transform MessageContainerBox;
  public GameObject Message;
  public bool ConnectionStatus;
  public string dataReceived;
  public string ServerUrl;
  public string Username;
  public WebSocketWorker.Message_Detail Message_;

  private void Start()
  {
    // ISSUE: method pointer
    this.ReConnectButton.onClick.AddListener(new UnityAction((object) this, __methodptr(ReConnect)));
    this.ws = new WebSocket(this.ServerUrl, Array.Empty<string>());
    this.ws.Connect();
    this.ws.Send("{\"id\": " + 0.ToString() + ", \"username\": \"" + this.Username + "\", \"messageData\": \"\"}");
    // ISSUE: method pointer
    this.ws.OnMessage += new EventHandler<MessageEventArgs>((object) this, __methodptr(\u003CStart\u003Eb__10_0));
  }

  private void Update()
  {
    if (this.ws == null)
    {
      Debug.Log((object) "The url is wrong or your server is not on!");
      this.ReConnectButton.gameObject.SetActive(true);
      this.ConnectionStatus = false;
    }
    else
    {
      this.ReConnectButton.gameObject.SetActive(false);
      this.ConnectionStatus = true;
    }
  }

  public void ReConnect()
  {
    this.ws = new WebSocket(this.ServerUrl, Array.Empty<string>());
    this.ws.Connect();
  }

  public void SendMessageParameter(string USERNAME, string MessageParameter)
  {
    string data;
    if (USERNAME == null)
      data = "{\"id\": " + 0.ToString() + ", \"username\": \"" + this.Username + "\", \"messageData\": \"" + MessageParameter + "\"}";
    else
      data = "{\"id\": " + 0.ToString() + ", \"username\": \"" + USERNAME + "\", \"messageData\": \"" + MessageParameter + "\"}";
    this.ws.Send(data);
  }

  private void WriteMessage()
  {
    if (this.Message_.username == this.Username)
      this.Message_.username = "Me";
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Message, (Vector3) new Vector2(0.0f, 0.0f), Quaternion.identity);
    gameObject.AddComponent<MessageWriter>();
    string[] strArray = new string[2]{ "[%01%", "[%02%" };
    if (this.Message_.username.Contains(strArray[0]))
    {
      gameObject.GetComponent<MessageWriter>().CustomColour = true;
      this.Message_.username.Replace(strArray[0], "");
      gameObject.GetComponent<MessageWriter>().username = this.Message_.username.Replace(strArray[0], "[");
    }
    else
      gameObject.GetComponent<MessageWriter>().username = this.Message_.username;
    gameObject.GetComponent<MessageWriter>().message = this.Message_.messageData;
    gameObject.name = this.Message_.id.ToString();
    gameObject.transform.SetParent(this.MessageContainerBox, true);
  }

  public WebSocketWorker()
  {
    this.Message_ = new WebSocketWorker.Message_Detail();
    base.\u002Ector();
  }

  [CompilerGenerated]
  private void \u003CStart\u003Eb__10_0(object sender, MessageEventArgs e)
  {
    this.dataReceived = e.Data;
    this.Message_ = JsonUtility.FromJson<WebSocketWorker.Message_Detail>(this.dataReceived);
    this.WriteMessage();
  }

  [Serializable]
  public class Message_Detail
  {
    public int id;
    public string username;
    public string messageData;

    public Message_Detail()
    {
      base.\u002Ector();
    }
  }
}
