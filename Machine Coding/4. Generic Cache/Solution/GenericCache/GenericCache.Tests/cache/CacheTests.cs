using GenericCache.App.src.cache;
using GenericCache.App.src.enums;
using Xunit;

namespace GenericCache.Tests.cache
{
    public class CacheTests
    {
        private ICache<int, string> _cache;

        public CacheTests()
        {
            _cache = new CacheFactory<int, string>(StorageType.DICTIONARY, EvictionPolicyType.DATETIME).GetCache();
        }

        [Theory]
        [InlineData(1, "Value1")]
        [InlineData(2, "Value2")]
        [InlineData(3, "Value3")]
        [InlineData(4, "Value4")]
        [InlineData(5, "Value5")]
        [InlineData(6, "Value6")]
        [InlineData(2, "Value20")]
        [InlineData(6, "Value60")]
        public void ShouldReadTheLatestWrites(int key, string value)
        {
            _cache.Put(key, value);

            var val = _cache.Get(key);
            Assert.IsType<string>(val);
            Assert.Equal(val, value);
        }
    }
}
