using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    //Microsoft Ürünüdür.
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern (Adaptasyon Deseni) Uyguladık.

        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key,value,TimeSpan.FromMinutes(10)); //Key,value ve duration değerlerinin girilmesi gerekmektedir. 
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key); //MemoryCache'ten Get et ama hangi türden get anlamına gelmektedir.
        }

        public object Get(string key)//Object veri tipinde hertürlü veriler kullanılmaktadır.Ancak bu verileri "var"a göre kullanabilmek için Unboxing(Kutudan çıkarma) işlemi uygulanmalıdır.

        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)//Cache'te böyle bir değer varmı anlamına gelmektedir.
        {
            return _memoryCache.TryGetValue(key, out _);//Ben sadece bellekte böyle bir anahtar varmı yada yokmu öğrenmek istiyorum değeri değil varlığından haberdar olmak istiyorum. 
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            //Bu metod ona verilen Pattern'a göre silme işlemini gerçekleştirecektir.
            //Çalışma anında bellekten silmeye yarar.
            //Reflection çalışma anında elimizde olmayan nesneleri oluşturma ve silme işlemlerini gerçekleştirebilmemiz için kullanılır.
            
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //Cache'lenen veriler "EntriesCollection" içerisine atılmaktadır.Microsoft tarafından tanımlanan default değer budur.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;//Definition'ı memorycache olanı bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)//Herbir Cache elemanını gez
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
                //Kurala uyanları çek anlamına gelmektedir.
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
