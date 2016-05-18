using System;
using System.Linq;
using BOFI.Dao;
using BOFI.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Sdk;

namespace BOFI.Tests
{

    public class UnitTest1
    {
        private readonly BoardGameDao _sut = new BoardGameDao();


        [Fact( DisplayName = "Should return empty result")]
        public void FirstTimeGettingAllItems()
        {

            var response = _sut.GetAll();
            //response.Should().NotBeEmpty();
            response.Should().BeEmpty();
        }
        [Fact(DisplayName = "Should not return empty result")]
        public void SecondTimeGettingAllItems()
        {

            var response = _sut.GetAll();
            response.Should().NotBeEmpty();
            response.Count().Should().Be(1);
        }
        [Fact]
        public void Add()
        {
            var response = _sut.Add(new BoardGame
            {
                Id = Guid.NewGuid().ToString(),
                Name = "My first test",
                Description = "My first description",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now

            });

            response.Should().NotBeNull();

        }

        [Fact]
        public void Update()
        {
            var response = _sut.Update(new BoardGame
            {
                Id = "6d5d55d3-d506-41ec-ac57-aa77926cb936",
                Name= "mody"
            });

            response.Should().BeTrue();
        }

        [Fact(Skip = "no")]
        public void UpdateSadPath()
        {
            var response = _sut.Update(new BoardGame
            {
                Id = "c11ae7dd-d9ea-46d0-af03-cdcd481daasdasd",
                Name= "mody"
            });
            response.Should().BeFalse();
        }
    }
}
