using GenericCache.App.src.cache;
using GenericCache.App.src.enums;
using Xunit;

namespace GenericCache.Tests.cache
{
    public class CacheTests
    {

        /// <summary>
        /// Taking cache with 'key of type int' and 'value of type string'
        /// </summary>
        /// <param name="storageType"></param>
        /// <param name="evictionPolicyType"></param>
        [Theory]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.LRU)]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.DATETIME)]
        public void TestInt_StringTypeWithDiffStoresAndPolicies(StorageType storageType, EvictionPolicyType evictionPolicyType)
        {
            // Arrange
            const int _cacheCapacity = 4;
            ICache<int, string> _cache = new CacheFactory<int, string>(storageType, evictionPolicyType, _cacheCapacity).GetCache();
            _cache.Purge();
            
            // Act
            _cache.Put(1, "Value1");
            _cache.Put(2, "Value2");
            _cache.Put(3, "Value3");
            _cache.Put(4, "Value4");
            _cache.Put(5, "Value5");
            _cache.Put(6, "Value6");
            _cache.Put(2, "Value20");
            _cache.Put(6, "Value60");

            // Assert
            Assert.Null(_cache.Get(1)); // Got evicted
            Assert.Equal("Value20", _cache.Get(2));
            Assert.Null(_cache.Get(3)); // Got evicted
            Assert.Equal("Value4", _cache.Get(4));
            Assert.Equal("Value5", _cache.Get(5));
            Assert.Equal("Value60", _cache.Get(6));
        }

        /// <summary>
        /// Taking cache with 'key of type string' and 'value of type double'
        /// </summary>
        /// <param name="storageType"></param>
        /// <param name="evictionPolicyType"></param>
        [Theory]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.LRU)]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.DATETIME)]
        public void TestString_DoubleTypeWithDiffStoresAndPolicies(StorageType storageType, EvictionPolicyType evictionPolicyType)
        {
            // Arrange
            const int _cacheCapacity = 4;
            ICache<string, double?> _cache = new CacheFactory<string, double?>(storageType, evictionPolicyType, _cacheCapacity).GetCache();
            _cache.Purge();

            // Act
            _cache.Put("Key1", 1.001);
            _cache.Put("Key2", 2.002);
            _cache.Put("Key3", 3.003);
            _cache.Put("Key4", 4.004);
            _cache.Put("Key5", 5.005);
            _cache.Put("Key6", 6.006);
            _cache.Put("Key2", 20.0020);
            _cache.Put("Key6", 60.0060);

            // Assert
            Assert.Null(_cache.Get("Key1")); // Got evicted
            Assert.Equal(20.0020, _cache.Get("Key2"));
            Assert.Null(_cache.Get("Key3")); // Got evicted
            Assert.Equal(4.004, _cache.Get("Key4"));
            Assert.Equal(5.005, _cache.Get("Key5"));
            Assert.Equal(60.0060, _cache.Get("Key6"));
        }
    }
}
