using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaxxLibrary.Engine
{
    public sealed class Engine
    {
        private static volatile Engine instance;
        private static object syncKey = new Object();

        private Engine() {}

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncKey)
                    {
                        if (instance == null)
                        {
                            instance = new Engine();
                        }
                    }
                }

                return instance;
            }
        }
    }
}


