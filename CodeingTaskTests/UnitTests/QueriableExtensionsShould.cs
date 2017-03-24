using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FTDNA_Coding_Task.Data;
using System.Collections.Generic;
using System.Linq;
namespace CodeingTaskTests
{
    [TestClass]
    public class QueriableExtensionsShould
    {
        [TestMethod]
        public void ReturnChangedResultWhenConditionDoesMatch()
        {
			// test data
			IQueryable<int> values = (new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).AsQueryable();
			
			var result = values.AddOptionalQueryPart(() => true, v => v.Where(x => (x % 2) == 1));
			Assert.AreEqual(5, result.Count());
			Assert.AreEqual(9, result.Max());
			Assert.AreEqual(1, result.Min());
		}

		[TestMethod]
		public void ReturnUnchangedResultWhenConditionDoesNotMatch()
		{
			// test data
			IQueryable<int> values = (new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).AsQueryable();

			var result = values.AddOptionalQueryPart(() => false, v => v.Where(x => (x % 2) == 1));
			Assert.AreEqual(9, result.Count());
			Assert.AreEqual(9, result.Max());
			Assert.AreEqual(1, result.Min());
		}
	}
}
