using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.Common
{
    /// <summary>
    /// This cache class provides a generic managed storeage area in memory for data.
    /// The specified maximum size is enforced by removing the oldest data entry if max size
    /// has been reached and a new item is added. Requested items are moved back to the top 
    /// of the queue so that the most frequently accesed items will not have to be reloaded.
    /// 
    /// A 'data valid' time period can be specified that provides a data expiry time for
    /// each cache element. if data is requested and it has expired then an event is fired 
    /// to request an update.
    /// </summary>
    /// <typeparam name="KeyType"></typeparam>
    /// <typeparam name="DataType"></typeparam>
    public class Cache<KeyType, DataType>  
    {
        public delegate void DataUpdateNeededHandler(object myObject, 
            DataUpdateNeededArgs<KeyType, DataType> args);
        public event DataUpdateNeededHandler DataUpdateNeeded;

        // Keys is a list of the keys of the objects held in the cache ordered by last access time.
        // The most recently accessed is the 'first' item.
        private LinkedList<KeyType> _keys;
        private Dictionary<KeyType, CacheItem<DataType>> _cache;
        private int _maxSize;
        private TimeSpan _dataValidPeriod;

        /// <summary>
        /// Cache constructor. The cache is initialised to the specified maximum size though
        /// it initialy contains no data.
        /// Data will never expire.
        /// </summary>
        /// <param name="maxSize">The is the maximum number of data elements held in the cache.</param>
        public Cache(int maxSize)
        {
            _maxSize = maxSize;
            _dataValidPeriod = TimeSpan.MaxValue;
            _keys = new LinkedList<KeyType>();
            _cache = new Dictionary<KeyType, CacheItem<DataType>>(_maxSize);
        }

        /// <summary>
        /// Cache constructor. The cache is initialised to the specified maximum size though
        /// it initialy contains no data.
        /// </summary>
        /// <param name="maxSize">The is the maximum number of data elements held in the cache.</param>
        /// <param name="dataValidPeriod"></param>
        public Cache(int maxSize, TimeSpan dataValidPeriod)
        {
            _maxSize = maxSize;
            _dataValidPeriod = dataValidPeriod;
            _keys = new LinkedList<KeyType>();
            _cache = new Dictionary<KeyType, CacheItem<DataType>>(_maxSize);
        }

        /// <summary>
        /// Add the specified item to the cache. It will be indexed using the supplied key value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void Add(KeyType key, DataType item)
        {
            if (_keys.Contains(key))
            {
                _cache.Remove(key);
                _keys.Remove(key);
            }
            else if (_keys.Count > _maxSize)
            {
                _cache.Remove(_keys.Last.Value);
                _keys.RemoveLast();
            }

            _keys.AddFirst(key);
            _cache.Add(key, new CacheItem<DataType>(item));
        }

        /// <summary>
        /// Get the data associated with the specified key value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataType Get(KeyType key)
        {
            DataType retVal = default(DataType);
            CacheItem<DataType> item;
            bool dataUpdateRequest = false;
            bool inCache = false;

            if (_cache.TryGetValue(key, out item))
            {
                inCache = true;
                // check the data expiry time..
                if (_dataValidPeriod.CompareTo(TimeSpan.MaxValue) == 0 ||
                    item.LastUpdated.Add(_dataValidPeriod).CompareTo(DateTime.UtcNow) > 0)
                {
                    // ..If the data is still valid then set the return value.
                    retVal = item.Data;
                    // and move this item to the top of the access list.
                    _keys.Remove(key);
                    _keys.AddFirst(key);
                }
                else if (_dataValidPeriod.CompareTo(TimeSpan.MaxValue) != 0)
                {
                    // ..otherwise, we need to request an update.
                    dataUpdateRequest = true;
                }

            }
            else
            {
                // If the item is not in the cache then we need a data update.
                dataUpdateRequest = true;
            }

            if (dataUpdateRequest)
            {
                if (DataUpdateNeeded != null)
                {
                    DataUpdateNeededArgs<KeyType, DataType> args =
                        new DataUpdateNeededArgs<KeyType, DataType>(key, ref retVal);
                    DataUpdateNeeded(this, args);
                    if (args.Data != null)
                    {
                        if (inCache)
                        {
                            _cache.Remove(key);
                            _keys.Remove(key);
                        }
                        this.Add(key, args.Data);
                        retVal = args.Data;
                    }
                }
            }

            return retVal;
        }

        #region CacheItem inner class
        /// <summary>
        /// The CacheItem class provides a wrapper that combines a specified datatype object with
        /// functionality that is commonly required in a cached item.
        /// </summary>
        /// <typeparam name="DataType"></typeparam>
        public class CacheItem<ItemDataType>
        {
            private DateTime _updated;
            private ItemDataType _data;

            public ItemDataType Data
            {
                get { return _data; }
                set
                {
                    _data = value;
                    _updated = DateTime.UtcNow;
                }
            }

            public DateTime LastUpdated
            {
                get { return _updated; }
                //set { _updated = value; }
            }

            public CacheItem(ItemDataType data)
            {
                _data = data;
                _updated = DateTime.UtcNow;
            }
        }
        #endregion
    }


    public class DataUpdateNeededArgs<KeyType, DataType> : EventArgs
    {
        private KeyType _key;
        private DataType _data;

        public DataUpdateNeededArgs(KeyType key, ref DataType data)
        {
            _key = key;
            _data = data;
        }


        public KeyType Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public DataType Data
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
