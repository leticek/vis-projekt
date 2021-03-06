﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public sealed class FirestoreSingleton
    {
        FirestoreSingleton()
        {
        }
        private static readonly string path = "creds.json";
        private static readonly object padlock = new object();
        private static FirestoreDb instance = null;
        public static FirestoreDb Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                        instance = FirestoreDb.Create("vis-project-74d55");
                    }
                    return instance;
                }
            }
        }
    }
}
