using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlyForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestEntity> testEntities = new List<TestEntity>();
            for (int i = 0; i < 20; i++)
            {
                TestEntity testEntity = new TestEntity() { Id = i + 1, Name = $"sniper{i + 1}" ,List=new List<string> {$"{i}",$"sniper{i+1}" } };
                testEntities.Add(testEntity);
            }

            var list1 = testEntities.Select(p => p.List).ToList();
            var list2 = testEntities.SelectMany(p => p.List).ToList();


        }
    }
}
