using GenericCache.App.src.cache;
using GenericCache.App.src.enums;
using Xunit;

namespace GenericCache.Tests.cache
{
    public class CacheTests
    {

        [Theory]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.LRU)]
        [InlineData(StorageType.DICTIONARY, EvictionPolicyType.DATETIME)]
        public void TestWithDiffStoresAndPolicies(StorageType storageType, EvictionPolicyType evictionPolicyType)
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
    }
}
