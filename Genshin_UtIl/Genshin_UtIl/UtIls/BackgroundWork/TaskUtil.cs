using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


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
}
