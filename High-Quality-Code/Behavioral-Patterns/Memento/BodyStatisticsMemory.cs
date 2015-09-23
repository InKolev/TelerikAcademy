using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class BodyStatisticsMemory
    {
        public BodyStatisticsMemory()
        {
            this.Stats = new Dictionary<int, BodyStatistics>();
        }

        public BodyStatisticsMemory(Dictionary<int, BodyStatistics> stats)
        {
            this.Stats = stats;
        }

        private Dictionary<int, BodyStatistics> Stats { get; set; }

        private int LastKey { get; set; } = 0;

        private int CurrentKey { get; set; } = 0;

        public void Add(BodyStatistics stats)
        {
            this.LastKey++;
            this.CurrentKey = this.LastKey;

            this.Stats.Add(this.LastKey, stats);
        }

        public void Clear(BodyStatistics stats)
        {
            this.Stats.Clear();
        }

        public BodyStatistics Previous()
        {
            // Validation
            return this.Stats[--this.CurrentKey];
        }

        public BodyStatistics Next()
        {
            // Validation
            return this.Stats[++this.CurrentKey];
        }
    }
}
