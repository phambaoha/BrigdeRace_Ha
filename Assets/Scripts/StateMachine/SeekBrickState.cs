using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : IState
{
    int targetBrick;
    public void OnEnter(BotController botController)
    {
        targetBrick = Random.Range(3, 7);
        botController.SetDestionation(GetPosBrick(botController));
    }

    public void OnExecute(BotController botController)
    {
        if (botController.IsDestination)
        {
            //check da du gach hay chua
            //+change state finish
            //-botController.SetDestionation(GetPosBrick(botController));

        }
    }

    public void OnExit(BotController botController)
    {
       
    }


    Vector3 vt3;
    public Vector3 GetPosBrick(BotController bot)
    {
        for(int i =0; i< bot.brickGenerator.spawnedBricks.Length ; i++)
        {
            if (bot.brickGenerator.spawnedBricks[i] != null && bot.characterColor == bot.brickGenerator.spawnedBricks[i].brickColorName)
            {
                vt3 = bot.brickGenerator.spawnedBricks[i].position;
                break;
            }
        }
        return vt3;
    }
}
