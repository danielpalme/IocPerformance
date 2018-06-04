using System;
using System.Collections.Generic;

namespace IocPerformance
{
    /*
         Based on the implementation of Adam Horvath (CustomDictionary)
         http://blog.teamleadnet.com/2012/07/ultra-fast-hashtable-dictionary-with.html
    */

    internal sealed class IocPerformanceDictionary<TKey, TValue>
        where TKey : class
        where TValue : class
    {
        private const int initialsize = 89;

        private static readonly uint[] primeSizes = new uint[]{ 89, 179, 359, 719, 1439, 2879, 5779, 11579, 23159, 46327,
                                        92657, 185323, 370661, 741337, 1482707, 2965421, 5930887, 11861791,
                                        23723599, 47447201, 94894427, 189788857, 379577741, 759155483};

        private int[] buckets;
        private IocPerformanceDictionaryEntry[] entries;
        private int nextfree;
        public IocPerformanceDictionary() => Initialize();
        public int Count => nextfree;

        public TValue this[TKey key]
        {
            get
            {
                uint pos = (uint)key.GetHashCode() % (uint)buckets.Length;
                int entryLocation = buckets[pos];

                if (entryLocation == -1)
                    return null;

                int nextpos = entryLocation;

                do
                {
                    var entry = entries[nextpos];

                    if (key.Equals(entry.key))
                        return entries[nextpos].value;

                    nextpos = entry.next;
                }
                while (nextpos != -1);

                return null;
            }
            set
            {
                if (nextfree >= entries.Length)
                    Resize();

                uint hash = (uint)key.GetHashCode();
                uint hashPos = hash % (uint)buckets.Length;
                int entryLocation = buckets[hashPos];
                int storePos = nextfree;

                if (entryLocation != -1)
                {
                    int currEntryPos = entryLocation;

                    do
                    {
                        var entry = entries[currEntryPos];
                        if (key.Equals(entry.key))
                            return;

                        currEntryPos = entry.next;
                    }
                    while (currEntryPos > -1);

                    nextfree++;
                }
                else
                    nextfree++;

                buckets[hashPos] = storePos;
                entries[storePos] = new IocPerformanceDictionaryEntry
                {
                    next = entryLocation,
                    key = key,
                    value = value,
                    hashcode = hash
                };
            }
        }
        
        private uint FindNewSize()
        {
            uint roughsize = (uint)buckets.Length * 2 + 1;

            for (int i = 0; i < primeSizes.Length; i++)
                if (primeSizes[i] >= roughsize)
                    return primeSizes[i];

            throw new NotImplementedException("Too large array");
        }

        private void Initialize()
        {
            this.buckets = new int[initialsize];
            this.entries = new IocPerformanceDictionaryEntry[initialsize];
            nextfree = 0;

            for (int i = 0; i < entries.Length; i++)
                buckets[i] = -1;
        }

        private void Resize()
        {
            var newsize = FindNewSize();
            var newhashes = new int[newsize];
            var newentries = new IocPerformanceDictionaryEntry[newsize];

            Array.Copy(entries, newentries, nextfree);

            for (int i = 0; i < newsize; i++)
                newhashes[i] = -1;

            for (int i = 0; i < nextfree; i++)
            {
                uint pos = newentries[i].hashcode % newsize;
                int prevpos = newhashes[pos];
                newhashes[pos] = i;

                if (prevpos != -1)
                    newentries[i].next = prevpos;
            }

            buckets = newhashes;
            entries = newentries;
        }

        private class IocPerformanceDictionaryEntry
        {
            public uint hashcode;
            public TKey key;
            public int next;
            public TValue value;
        }
    }
}