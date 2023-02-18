using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using static Genshin_UtIl.UtIls.BackgroundWork.TaskUtil;

namespace Genshin_UtIl.UtIls.BackgroundWork
{
    public class TaskUtil
    {
        public delegate Task BackgroundTaskDelegate();

        public BackgroundTaskDelegate TaskDelegate;

        public Task TaskStorage;

        public CancellationTokenSource Cancel = new();

        public void StartTask()
        {
            TaskStorage = ConsumeTask();
        }

        async Task ConsumeTask()
        {
            foreach (var task in ProduceTask(Cancel.Token))
            {
                await task;
            }
        }

        public void CancelTask() => Cancel.Cancel();

        IEnumerable<Task> ProduceTask(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                yield return TaskDelegate();
            }
        }

        public TaskUtil(BackgroundTaskDelegate taskdelegate)
        {
            TaskDelegate = taskdelegate;
        }
    }

    public class TaskUtil<T>
    {
        public delegate Task BackgroundTaskDelegate<T>(T var);

        public BackgroundTaskDelegate<T> TaskDelegateGeneric;

        public Task TaskStorage;

        public CancellationTokenSource Cancel = new();

        public void StartTask(T var)
        {
            TaskStorage = ConsumeTask(var);
        }

        async Task ConsumeTask(T var)
        {
            foreach (var task in ProduceTask(var, Cancel.Token))
            {
                await task;
            }
        }

        public void CancelTask() => Cancel.Cancel();

        IEnumerable<Task> ProduceTask(T var, CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                yield return TaskDelegateGeneric(var);
            }
        }

        public TaskUtil(BackgroundTaskDelegate<T> taskdelegate)
        {
            TaskDelegateGeneric = taskdelegate;
        }
    }
}
