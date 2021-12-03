using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MenuPlanner.Core;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace MenuPlanner.Tests.Tests
{
    public class UserFinderTests : TestSuitBase
    {
        public UserFinderTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        //[Fact(DisplayName = "find user ids for the given date ids")]
        //public void Get_Users_Having_Meal_In_Filtered_Days()
        //{
        //    // Arrange

        //    const string filePath = @"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data\2627.json";

        //    var sut = new UserFinder(filePath);

        //    var datesIds = new Filterer(filePath)
        //        .Filter(DateTime.Parse("2015-10-30"), DateTime.Parse("2015-11-05"));

        //    // Act

        //    var userIds = sut.FindUserIds(datesIds);

        //    // Assert

        //    Start_Verifying()
        //        .Verify(() => userIds.Count.ShouldBe(1));

        //    OutputHelper.WriteLine(userIds);
        //}

        //[Fact(DisplayName = "find user ids for all data files")]
        //public void Read_All_And_Deserialize()
        //{
        //    var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
        //        .GetFiles();

        //    foreach (var file in dataFiles)
        //    {
        //        // Arrange

        //        var sut = new UserFinder(file.FullName);

        //        var datesIds = new Filterer(file.FullName)
        //            .Filter(DateTime.Parse("2010-10-30"), DateTime.Parse("2020-11-05"));

        //        // TODO: remove conditional from test
        //        if (!datesIds.Any())
        //        {
        //            OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //            continue;
        //        }

        //        // Act

        //        var userIds = sut.FindUserIds(datesIds);

        //        // Assert

        //        OutputHelper.XUnitOutputHelper.WriteLine($"Attempted for file: [{file.Name}]");

        //        Start_Verifying()
        //            .Verify(() =>
        //                userIds.Single().ShouldBe(int.Parse(file.Name.Replace(Path.GetExtension(file.Name), ""))));

        //        OutputHelper.WriteLine(userIds);
        //    }
        //}

        //[Theory(DisplayName = "find all meals from all data files")]
        //[InlineData("2010-10-30", "2020-11-05")]
        //public void Find_All_Meals_Within_Date_Range(string fromStr, string toStr)
        //{
        //    var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
        //        .GetFiles();

        //    foreach (var file in dataFiles)
        //    {
        //        // Arrange

        //        var sut = new UserFinder(file.FullName);

        //        var datesIds = new Filterer(file.FullName)
        //            .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

        //        // TODO: remove conditional from test
        //        if (!datesIds.Any())
        //        {
        //            OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //            continue;
        //        }

        //        // Act

        //        var meals = sut.FindMealDetails(datesIds);

        //        // Assert

        //        OutputHelper.XUnitOutputHelper.WriteLine($"Attempted for file: [{file.Name}]");

        //        Start_Verifying()
        //            .Verify_Defined(meals, false)
        //            .Verify(() => meals.ShouldNotBeEmpty());

        //        OutputHelper.WriteLine(meals.Take(3));
        //    }
        //}

        //[Theory(DisplayName = "find active users within date range")]
        //[InlineData("2010-10-30", "2020-11-05")]
        //public void Find_Active_Users_Within_Date_Range(string fromStr, string toStr)
        //{
        //    // Arrange

        //    var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
        //        .GetFiles();

        //    var allMeals = new List<MealDto>();

        //    foreach (var file in dataFiles)
        //    {

        //        var sut = new UserFinder(file.FullName);

        //        var datesIds = new Filterer(file.FullName)
        //            .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

        //        // TODO: remove conditional from test
        //        if (!datesIds.Any())
        //        {
        //            OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //            continue;
        //        }

        //        allMeals.AddRange(sut.FindMealDetails(datesIds));
        //    }

        //    // Act

        //    var activeUsers = allMeals
        //        .GroupBy(x => x.UserId)
        //        .Select(x => new { x.Key, Total = x.Count() })
        //        .Where(x => x.Total >= 5 && x.Total <= 10)
        //        .ToList();

        //    // Assert

        //    Start_Verifying()
        //        .Verify_Defined(activeUsers)
        //        .Verify(() => activeUsers.ShouldNotBeEmpty());

        //    OutputHelper.WriteLine(activeUsers);
        //}

        //[Theory(DisplayName = "find super active users within date range")]
        //[InlineData("2010-10-30", "2020-11-05")]
        //public void Find_Super_Active_Users_Within_Date_Range(string fromStr, string toStr)
        //{
        //    // Arrange

        //    var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
        //        .GetFiles();

        //    var allMeals = new List<MealDto>();

        //    foreach (var file in dataFiles)
        //    {

        //        var sut = new UserFinder(file.FullName);

        //        var datesIds = new Filterer(file.FullName)
        //            .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

        //        // TODO: remove conditional from test
        //        if (!datesIds.Any())
        //        {
        //            OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //            continue;
        //        }

        //        allMeals.AddRange(sut.FindMealDetails(datesIds));
        //    }

        //    // Act

        //    var activeUsers = allMeals
        //        .GroupBy(x => x.UserId)
        //        .Select(x => new { x.Key, Total = x.Count() })
        //        .Where(x => x.Total > 10)
        //        .ToList();

        //    // Assert

        //    Start_Verifying()
        //        .Verify_Defined(activeUsers)
        //        .Verify(() => activeUsers.ShouldNotBeEmpty());

        //    OutputHelper.WriteLine(activeUsers);
        //}

        //[Theory(DisplayName = "find bored users within date range")]
        //[InlineData("2010-10-30", "2020-11-05")]
        //public void Find_Bored_Users_Within_Date_Range(string fromStr, string toStr)
        //{
        //    // Arrange

        //    var dataFiles = new DirectoryInfo(@"C:\me-repo\unit-testing-101\MenuPlanner.Console\Data")
        //        .GetFiles();


        //    var activeMinThreshold = DateTime.MinValue;
        //    var activeMaxThreshold = DateTime.Parse(fromStr);


        //    // TODO: duplicate in Find_Active_Users_Within_Date_Range
        //    //var allMeals = new List<MealDto>();

        //    //foreach (var file in dataFiles)
        //    //{

        //    //    var sut = new UserFinder(file.FullName);

        //    //    var datesIds = new Filterer(file.FullName)
        //    //        .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

        //    //    // TODO: remove conditional from test
        //    //    if (!datesIds.Any())
        //    //    {
        //    //        OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //    //        continue;
        //    //    }

        //    //    allMeals.AddRange(sut.FindMealDetails(datesIds));
        //    //}

        //    var allMeals = new List<MealDto>();

        //    foreach (var file in dataFiles)
        //    {

        //        var sut = new UserFinder(file.FullName);

        //        var datesIds = new Filterer(file.FullName)
        //            .Filter(DateTime.Parse(fromStr), DateTime.Parse(toStr));

        //        // TODO: remove conditional from test
        //        if (!datesIds.Any())
        //        {
        //            OutputHelper.XUnitOutputHelper.WriteLine($"Skipping file: [{file.Name}]");
        //            continue;
        //        }

        //        allMeals.AddRange(sut.FindMealDetails(datesIds));
        //    }

        //    // Act

        //    var activeUsers = allMeals
        //        .GroupBy(x => x.UserId)
        //        .Select(x => new { x.Key, Total = x.Count() })
        //        .Where(x => x.Total > 10)
        //        .ToList();

        //    // Assert

        //    Start_Verifying()
        //        .Verify_Defined(activeUsers)
        //        .Verify(() => activeUsers.ShouldNotBeEmpty());

        //    OutputHelper.WriteLine(activeUsers);
        //}
    }
}