// Decompiled with JetBrains decompiler
// Type: Sender
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B34C14AB-0760-406D-ABE6-62CD929EE8CE
// Assembly location: *//*
// Compiler-generated code is shown

using UnityEngine;
using UnityEngine.UI;

public class Sender : MonoBehaviour
{
  public InputField MessageInput;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.Return) || !(this.MessageInput.text != ""))
      return;
    Object.FindAnyObjectByType<WebSocketWorker>().SendMessageParameter((string) null, this.MessageInput.text);
    this.MessageInput.text = "";
    this.MessageInput.Select();
  }

  public Sender()
  {
    base.\u002Ector();
  }
}
