using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequentialEnabler : MonoBehaviour
{

    public GameObject[] sequence;
    private int currentItemIndex = 0;   //TODO: needed ?..

    public UnityEvent reachedTheEnd;

    public int CurrentItem
    {
        get
        {
            return currentItemIndex;
        }
    }

    void Awake()
    {
        for (int i = 1; i < sequence.Length; i++)
        {
            sequence[i].SetActive(false);
        }

        currentItemIndex = 0;
        //explicitly enable the first one
        sequence[currentItemIndex].SetActive(true);
    }

    public int GetNextIndex()
    {
        int nextIndex = currentItemIndex + 1;

        if (nextIndex < sequence.Length)
        {
            return nextIndex;
        }
        else
        {
            return -1;
        }
    }

    public int GetPreviousIndex()
    {
        int prevIndex = currentItemIndex - 1;
        if (prevIndex>0)
        {
            return prevIndex;
        }
        else
        {
            return -1;
        }
    }

    public void EnableNextItem()
    {

        int indexToEnable = GetNextIndex();
        print(indexToEnable);
        if (indexToEnable > -1)
        {
            sequence[currentItemIndex].SetActive(false);
            sequence[indexToEnable].SetActive(true);
            currentItemIndex = indexToEnable;
        }

        if (indexToEnable < 0)
        {
            //reached the end
            reachedTheEnd.Invoke();
        }


    }

    public void EnablePreviousItem()
    {

        int indexToEnable = GetPreviousIndex();
        if (indexToEnable > -1)
        {
            sequence[currentItemIndex].SetActive(false);
            sequence[indexToEnable].SetActive(true);
            currentItemIndex = indexToEnable;
        }


        if (currentItemIndex == sequence.Length - 1)
        {
            //reached the end
            reachedTheEnd.Invoke();
        }

    }
}
