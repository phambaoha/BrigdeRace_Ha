using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{

    // bat dau su kien
    void OnEnter(BotController botController);

    // xu ly di chuyen, ...
    void OnExecute(BotController botController);

    // thoat su kien
    void OnExit(BotController botController);



}
  

