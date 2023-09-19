using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GCS.Framework.Caching;
using GCS.Core.Common;
using GCS.Core.Common.Extensions;

namespace RedisCacheClient
{
    public class MainViewModel: ObservableObject
    {
        private string _redisUrl = "localhost:6379";
        private string _searchKey = string.Empty;
        private ICacheManager _cacheManager = new RedisCacheManager();


        public MainViewModel()
        {
            SearchCommand = new RelayCommand(SearchForKeys);
            DeleteKeyCommand = new RelayCommand<string>(DeleteKey);
            _cacheManager.Enabled = true;
        }

        public string RedisUrl
        {
            get => _redisUrl;
            set => SetProperty(ref _redisUrl, value);
        }

        public int KeyCount
        {
            get => _keyCount;
            set => SetProperty(ref _keyCount, value);
        }

        public string SearchKey
        {
            get => _searchKey;
            set => SetProperty(ref _searchKey, value);
        }

        public ICommand SearchCommand
        {
            get;
        }

        public ICommand DeleteKeyCommand
        {
            get;
        }

        private ObservableCollection<string> _searchResult;
        private int _keyCount;

        public ObservableCollection<string> SearchResults
        {
            get => _searchResult;
            set => SetProperty(ref _searchResult, value);
        }

        private async void SearchForKeys()
        {
            if (!_cacheManager.IsInitialized)
            {
                var cacheManagerInitialized = _cacheManager.Initialize(RedisUrl);
            }

            if (_cacheManager.IsInitialized)
            {
                IEnumerable<string> keys;
                if (string.IsNullOrEmpty(SearchKey))
                {
                    keys = await _cacheManager.GetAllKeysAsync();
                }
                else
                {
                    keys = await _cacheManager.GetKeysAsync(SearchKey);
                }

                if( keys != null)
                    SearchResults = keys.ToObservableCollection();
                else
                {
                    SearchResults = new ObservableCollection<string>();
                }

                KeyCount = SearchResults.Count;
            }
        }

        private async void DeleteKey(string key)
        {
            if (_cacheManager.IsInitialized )
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var bDeleted = await _cacheManager.DeleteCachedItemAsync(key);
                    if (bDeleted)
                        SearchResults.Remove(key);
                    KeyCount = SearchResults.Count;
                }
                else
                {   // Delete everything - Must have FLUSHDB option enabled in Redis
                    //var bDeletedAll = await _cacheManager.DeleteCachedItemAsync(key);
                    foreach (var k in SearchResults.ToList())
                    {
                        var bDeleted = await _cacheManager.DeleteCachedItemAsync(k);
                        if (bDeleted)
                            SearchResults.Remove(k);
                        KeyCount = SearchResults.Count;
                    }
                    SearchForKeys();
                }

            }
        }
    }
}
