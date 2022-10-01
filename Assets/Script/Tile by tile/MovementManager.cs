using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Range(.1f, 10)]
    public float timeForMovement;
    public AnimationCurve movementAnimCurve;
    public UI_TimeLineManager timeLineManager;
    
    public void Move(Vector3 destination, Transform player, UI_Actions.PlayerTarget playerTarget)
    {
        StartCoroutine(smoothMovement(player.position, destination, player, playerTarget));

    }

    IEnumerator smoothMovement(Vector3 startPos, Vector3 endPos, Transform player, UI_Actions.PlayerTarget playerTarget)
    {
        float i = 0;
        while(i < 1)
        {
            player.position = Vector3.Lerp(startPos, endPos, movementAnimCurve.Evaluate(i));

            i += Time.deltaTime * (1 / timeForMovement);
            yield return null;
        }
        player.position = endPos;

        GridGenerator.Instance.grid[(int)player.position.x, (int)player.position.z].TileEffect(playerTarget);
        yield return null;
        //yield return new WaitForSeconds(1);
/*        timeLineManager.currentIndex++;
        timeLineManager.LaunchTimeline();*/

    }
}
