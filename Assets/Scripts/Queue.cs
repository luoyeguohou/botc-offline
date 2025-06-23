using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class QueueHandler
{

    private Queue<Func<Task>> handlers = new Queue<Func<Task>>();
    private bool isHandling = false;
    public void PushData(Func<Task> data)
    {
        try
        {
            handlers.Enqueue(data);
            if (!isHandling)
            {
                _ = DoHandle();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    private async Task DoHandle()
    {
        try
        {
            if (isHandling) return;
            if (handlers.Count == 0) return;
            isHandling = true;
            while (handlers.Count > 0)
            {
                Func<Task> handler = handlers.Dequeue();
                await handler();
            }
            isHandling = false;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}