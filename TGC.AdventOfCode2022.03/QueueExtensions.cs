using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGC.AdventOfCode2022._03
{
    public static class QueueExtensions
    {
        public static IEnumerable<T> DequeueChunk<T>(this ConcurrentQueue<T> queue, int chunkSize)
        {
            lock (queue)
            {
                for (int i = 0; i < chunkSize && queue.Count > 0; i++)
                {
                    T item;
                    queue.TryDequeue(out item);
                    yield return item;
                }
            }
        }
    }
}
