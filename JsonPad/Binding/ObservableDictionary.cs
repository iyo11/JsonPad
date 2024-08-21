using System.Collections.Generic;
using System.Collections.Specialized;

namespace JsonPad.Binding
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private int _index;

        public new TValue this[TKey key]
        {
            get => this.GetValue(key);
            set => this.SetValue(key, value);
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, this.FindPair(key), _index));
        }

        public new void Clear()
        {
            base.Clear();
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public new bool Remove(TKey key)
        {
            var pair = this.FindPair(key);
            if (base.Remove(key))
            {
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, pair, _index));
                return true;
            }
            return false;
        }

        private TValue GetValue(TKey key)
        {
            if (ContainsKey(key))
                return base[key];
            else
                return default(TValue);
        }

        private void SetValue(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                base[key] = value;
                var pair = this.FindPair(key);
                var index = _index;
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, pair, pair, index));
            }
            else
            {
                this.Add(key, value);
            }
        }

        private KeyValuePair<TKey, TValue> FindPair(TKey key)
        {
            _index = 0;
            foreach (var pair in this)
            {
                if (pair.Key.Equals(key))
                    return pair;

                _index++;
            }
            return default(KeyValuePair<TKey, TValue>);
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.CollectionChanged?.Invoke(this, e);
        }
    }
}